using CommonSolution.Dto;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
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

        public void ReporteReclamo(DtoReclamo reclamo, string folder)
        {

        }
    }
}
