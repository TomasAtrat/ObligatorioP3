using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SautinSoft;

namespace DataAccess.HTML_GENERATOR
{
    public class GeneradorHTML
    {
        public GeneradorHTML()
        {

        }

        public string GenerarHTML(string folder, long id)
        {
            string PDFolder = folder + $"\\Reclamo{id}.pdf"; 
            string HTML_Folder= folder + $"\\Reclamo{id}.cshtml";
            PdfFocus f = new PdfFocus();
            f.OpenPdf(PDFolder);

            if (f.PageCount > 0)
            {
                int result = f.ToHtml(HTML_Folder);
            }

            return HTML_Folder;
        }

    }
}
