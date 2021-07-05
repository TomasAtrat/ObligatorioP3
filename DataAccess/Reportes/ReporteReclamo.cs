using CommonSolution.Dto;
using DataAccess.PDF_GENERATOR;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reportes
{
    public class ReclamoReporte
    {
        public ReclamoReporte()
        {
            this.gen = new GeneradorPDF();
        }

        private GeneradorPDF gen;

        public void GenerarReporte(DtoReclamo reclamo, string folder)
        {
            try
            {
                string DocumentTitle = $"Reclamo{reclamo.ID}";
                Document doc = this.gen.OpenDocument(folder, DocumentTitle);
                doc.Open();
                doc.Add(new Paragraph(DocumentTitle));
                doc.Add(Chunk.NEWLINE);
                iTextSharp.text.Font standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                doc.Add(new Paragraph($"ID Reclamo: {reclamo.ID}"));
                doc.Add(new Paragraph($"ID Tipo reclamo: {reclamo.IDTipoReclamo}"));
                doc.Add(new Paragraph($"ID Cuadrilla: {reclamo.IDCuadrilla}"));
                doc.Add(new Paragraph($"ID Zona: {reclamo.IDZona}"));
                doc.Add(new Paragraph($"Latitud: {reclamo.Latitud}"));
                doc.Add(new Paragraph($"Longitud: {reclamo.Longitud}"));
                doc.Add(new Paragraph($"Observaciones: {reclamo.Observaciones}"));
                doc.Add(new Paragraph($"Estado: {reclamo.Estado}"));
                doc.Add(new Paragraph($"Fecha y hora de ingreso: {reclamo.FechaHoraIngreso}"));
                string urlReclamo = "https://maps.google.com/?q=" + reclamo.Latitud + "," + reclamo.Longitud;
                this.gen.generarCodigoQR(urlReclamo, doc);
                this.gen.CloseDocument(doc);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
