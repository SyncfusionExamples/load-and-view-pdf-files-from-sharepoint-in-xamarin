using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharePoint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfViewerPage : ContentPage
    {
        public PdfViewerPage(PdfFile pdfFile)
        {
            InitializeComponent();
            this.Title = pdfFile.Name;
            pdfFile.DocumentStream.Position = 0;
            PdfViewer.LoadDocument(pdfFile.DocumentStream);
        }

        protected override void OnDisappearing()
        {
            PdfViewer.Dispose();
            base.OnDisappearing();
        }
    }
}