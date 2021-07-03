using CommonSolution.Dto;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PDF_GENERATOR
{
    public class GeneradorPDF
    {
        public GeneradorPDF()
        {

        }

        private PdfWriter writer;

        public Document OpenDocument(string folder, string DocumentTitle)
        {
            Document doc = new Document();

            try
            {
                doc.SetPageSize(PageSize.A4);
                doc.AddTitle(DocumentTitle);
                doc.AddCreator("Ayuntamiento de Toledo");
                this.writer = PdfWriter.GetInstance(doc, new FileStream(folder, FileMode.Create));
            }
            catch (Exception e)
            {
                throw e;
            }

            return doc;
        }

        public void CloseDocument(Document doc)
        {
            doc.Close();
            this.writer.Close();
        }

        public void generarCodigoQR(string url, Document doc)
        {
            BarcodeQRCode barcode = new BarcodeQRCode(url, 1000, 1000, null);
            Image BarcodeImg = barcode.GetImage();
            BarcodeImg.ScaleAbsolute(50, 50);
            doc.Add(BarcodeImg);
        }
    }
}
