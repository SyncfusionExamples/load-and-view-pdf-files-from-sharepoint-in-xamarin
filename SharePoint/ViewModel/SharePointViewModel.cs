using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using PnP.Framework;
using Syncfusion.TreeView.Engine;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SharePoint
{
    internal class SharePointViewModel
    {
        // Replace with your Sharepoint tenant name
        private const string Tenant = "{YOUR TENANT NAME}";

        // Replace with your targeted Sharepoint site name
        private const string SiteName = "{YOUR SITE NAME}";

        // Replace with your Azure AD Application's Client ID
        private const string ClientId = "{YOUR CLIENT ID}";

        // Replace with your Azure AD Application's Package Name or Bundle ID
        private const string AppId = "{YOUR APP ID}";

        // For Android, replace with your Authentication Signature Hash
        private const string SignatureHash = "{YOUR SIGNATURE HASH}";

        public ObservableCollection<FileManager> Documents { get; set; }
        public ClientContext Context { get; set; }
        public ICommand DocumentsViewOnDemandCommand { get; set; }

        public SharePointViewModel()
        {
            DocumentsViewOnDemandCommand = new Command(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }

        private bool CanExecuteOnDemandLoading(object sender)
        {
            var hasChildNodes = ((sender as TreeViewNode).Content as FileManager).HasChildNodes;
            if (hasChildNodes)
                return true;
            else
                return false;
        }

        private void ExecuteOnDemandLoading(object obj)
        {
            var node = obj as TreeViewNode;

            // Skip the repeated population of child items when every time the node expands.
            if (node.ChildNodes.Count > 0)
            {
                node.IsExpanded = true;
                return;
            }

            //Animation starts for expander to show progressing of load on demand
            node.ShowExpanderAnimation = true;

            Microsoft.SharePoint.Client.Folder root = (node.Content as FileManager).Folder;

            var documents = GetDocuments(root);

            node.PopulateChildNodes(documents);

            if (documents.Count > 0)
            {
                //Expand the node after child items are added.
                node.IsExpanded = true;
            }

            //Stop the animation after load on demand is executed, if animation not stopped, it remains still after execution of load on demand.
            node.ShowExpanderAnimation = false;
        }

        /// <summary>
        /// Perform SharePoint authentication and return the documents of the target site
        /// </summary>
        /// <returns>Documents of the target site</returns>
        internal async Task AuthenticateAndAcquireDocuments()
        {
            string redirectURI = DeviceInfo.Platform == DevicePlatform.Android ?
                $"msauth://{AppId}/{SignatureHash}" : $"msauth.{AppId}://auth";

            IPublicClientApplication PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithIosKeychainSecurityGroup(AppId)
                .WithRedirectUri(redirectURI)
                .WithAuthority("https://login.microsoftonline.com/common")
                .Build();

            var _scopes = new String[] { $"https://{Tenant}.sharepoint.com/AllSites.Read" }; //Replace with your own permissions

            try
            {
                AuthenticationResult authResult = await PublicClientApp.AcquireTokenInteractive(_scopes)
                    .WithParentActivityOrWindow(App.ParentWindow)
                    .WithUseEmbeddedWebView(true)
                    .ExecuteAsync();

                var authManager = new AuthenticationManager().GetAccessTokenContext(
                    $"https://{Tenant}.sharepoint.com/sites/{SiteName}",
                    authResult.AccessToken);

                Context = authManager.GetSiteCollectionContext();

                var web = Context.Web;//Gets target site web details
                var docs = web.Lists.GetByTitle("Documents");//Gets site's documents list
                var root = docs.RootFolder;  //Root folder

                Documents = GetDocuments(root);
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Returns the documents present in the passed root or parent folder
        /// </summary>
        /// <param name="root">Root folder</param>
        /// <returns>Documents of the root or parent folder</returns>
        internal ObservableCollection<FileManager> GetDocuments(Microsoft.SharePoint.Client.Folder root)
        {
            ObservableCollection<FileManager> documents = new ObservableCollection<FileManager>();

            Assembly assembly = typeof(DocumentsPage).GetTypeInfo().Assembly;

            Context.Load(root, f => f.ItemCount, f => f.Folders);
            Context.Load(root, f => f.ItemCount, f => f.Files);
            Context.ExecuteQuery();

            foreach (Microsoft.SharePoint.Client.Folder folder in root.Folders)
            {
                bool hasChildNodes = folder.ItemCount > 0 ? true : false;
                var folderItem = new FileManager()
                {
                    ItemName = folder.Name,
                    Folder = folder,
                    HasChildNodes = hasChildNodes,
                    ImageIcon = ImageSource.FromResource("SharePoint.Icons.treeview_folder.png", assembly)
                };
                documents.Add(folderItem);
            }

            foreach (Microsoft.SharePoint.Client.File file in root.Files)
            {
                if (file.Name.EndsWith(".pdf"))
                {
                    var fileItem = new FileManager()
                    {
                        ItemName = file.Name,
                        File = file,
                        ImageIcon = ImageSource.FromResource("SharePoint.Icons.treeview_pdf.png", assembly)
                    };
                    documents.Add(fileItem);
                }
            }

            return documents;
        }

        /// <summary>
        /// Returns the chosen PDF document details
        /// </summary>
        /// <param name="file">PDF file chosen from the File Explorer</param>
        /// <returns>PDF document details</returns>
        internal PdfFile GetPdfDocumentDetails(Microsoft.SharePoint.Client.File file)
        {
            MemoryStream PdfDocumentStream = new MemoryStream();
            var fileStream = file.OpenBinaryStream();
            Context.Load(file);
            Context.ExecuteQuery();
            fileStream.Value.CopyTo(PdfDocumentStream);
            PdfDocumentStream.Position = 0;
            return new PdfFile(PdfDocumentStream, file.Name);
        }
    }
}