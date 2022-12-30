using System.IO;

namespace SharePoint
{
    public class PdfFile
    {
        public Stream DocumentStream { get; set; }
        public string Name { get; set; }
        public PdfFile(Stream pdfStream,string pdfName)
        {
            DocumentStream = pdfStream;
            Name = pdfName;
        }
    }
}
