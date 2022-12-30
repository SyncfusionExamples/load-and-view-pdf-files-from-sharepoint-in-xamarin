using System;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharePoint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentsPage : ContentPage
    {
        public DocumentsPage()
        {
            InitializeComponent();
            SharepointImage.Source = ImageSource.FromResource("SharePoint.Icons.sharepoint.png",
                typeof(DocumentsPage).GetTypeInfo().Assembly);
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            ProgressBar.IsVisible = true;            
            LoginButton.IsVisible = false;

            await (BindingContext as SharePointViewModel).AuthenticateAndAcquireDocuments();

            SharepointImage.IsVisible = false;
            DocumentsTitleLabel.IsVisible = true;
            DocumentsView.IsVisible = true;

            DocumentsView.ItemsSource = (BindingContext as SharePointViewModel).Documents;

            ProgressBar.IsVisible = false;
        }

        private void DocumentsView_ItemTapped(object sender, Syncfusion.XForms.TreeView.ItemTappedEventArgs e)
        {
            Microsoft.SharePoint.Client.File file = (e.Node.Content as FileManager).File;

            if (file != null)
            {
                Navigation.PushAsync(new PdfViewerPage((BindingContext as SharePointViewModel)
                    .GetPdfDocumentDetails(file)));
            }
        }

        protected override void OnAppearing()
        {
            DocumentsView.SelectedItems.Clear();
            base.OnAppearing();
        }
    }
}