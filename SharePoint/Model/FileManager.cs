using System.ComponentModel;
using Xamarin.Forms;
using Microsoft.SharePoint.Client;

namespace SharePoint
{
    public class FileManager : INotifyPropertyChanged
    {
        #region Fields

        private string itemName;
        private bool hasChildNodes;
        private Folder folder;
        private File file;
        private ImageSource imageIcon;

        #endregion

        #region Constructor
        public FileManager()
        {
        }

        #endregion

        #region Properties

        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                RaisedOnPropertyChanged("ItemName");
            }
        }

        public bool HasChildNodes
        {
            get { return hasChildNodes; }
            set
            {
                hasChildNodes = value;
                RaisedOnPropertyChanged("HasChildNodes");
            }
        }

        public Folder Folder
        {
            get { return folder; }
            set
            {
                folder = value;
                RaisedOnPropertyChanged("Folder");
            }
        }

        public File File
        {
            get { return file; }
            set
            {
                file = value;
                RaisedOnPropertyChanged("File");
            }
        }

        public ImageSource ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
