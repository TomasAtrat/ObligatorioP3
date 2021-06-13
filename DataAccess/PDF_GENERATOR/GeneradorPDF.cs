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
            this.doc = new Document();
        }

        private Document doc;
        private PdfWriter writer;

        public void InitDocument(string folder, string DocumentTitle)
        {
            this.doc.SetPageSize(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(this.doc, new FileStream(folder, FileMode.Create));
            this.doc.AddTitle(DocumentTitle);
            this.doc.AddCreator("Tomás");
        }

        public void ReporteReclamo(DtoReclamo reclamo, string folder, string DocumentTitle)
        {
            InitDocument(folder, DocumentTitle);
            this.doc.Open();
            this.doc.Add(new Paragraph(DocumentTitle));
            this.doc.Add(Chunk.NEWLINE);
            iTextSharp.text.Font standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            this.doc.Add(new Paragraph($"ID Reclamo: {reclamo.ID}"));
            this.doc.Add(new Paragraph($"ID Tipo reclamo: {reclamo.IDTipoReclamo}"));
            this.doc.Add(new Paragraph($"ID Cuadrilla: {reclamo.IDCuadrilla}"));
            this.doc.Add(new Paragraph($"ID Zona: {reclamo.IDZona}"));
            this.doc.Add(new Paragraph($"Latitud: {reclamo.Latitud}"));
            this.doc.Add(new Paragraph($"Longitud: {reclamo.Longitud}"));
            this.doc.Add(new Paragraph($"Observaciones: {reclamo.Observaciones}"));
            this.doc.Add(new Paragraph($"Estado: {reclamo.Estado}"));
            this.doc.Add(new Paragraph($"Fecha y hora de ingreso: {reclamo.FechaHoraIngreso}"));
            string urlReclamo = $"https://maps.google.com/?q={reclamo.Latitud},{reclamo.Longitud}";
            generarCodigoQR(urlReclamo);
            this.doc.Close();
            writer.Close();
        }

        public void generarCodigoQR(string url)
        {
            BarcodeQRCode barcode = new BarcodeQRCode(url, 1000, 1000, null);
            Image BarcodeImg = barcode.GetImage();
            BarcodeImg.ScaleAbsolute(50, 50);
            this.doc.Add(BarcodeImg);
        }
    }
}
