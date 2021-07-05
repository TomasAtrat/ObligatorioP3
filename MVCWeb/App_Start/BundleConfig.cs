using System.Web;
using System.Web.Optimization;

namespace MVCWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/support/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/support/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/support/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/support/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/zonas").Include(
                         "~/Scripts/src/Zona.js"));

            bundles.Add(new ScriptBundle("~/bundles/VisorReclamos").Include(
                         "~/Scripts/src/VisorReclamos.js"));

            bundles.Add(new ScriptBundle("~/bundles/reclamos").Include(
                         "~/Scripts/src/Reclamo.js"));

            bundles.Add(new ScriptBundle("~/bundles/googleMaps").Include(
                     "~/Scripts/src/IniciarMapa.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/CSS/bootstrap.css",
                      "~/Content/CSS/bootstrap.min.css",
                      "~/Content/CSS/site.css",
                      "~/Content/CSS/starter-template.css"));

            bundles.Add(new StyleBundle("~/Content/CSS/css").Include(
                      "~/Content/CSS/bootstrap.css",
                      "~/Content/CSS/site.css"));

        }
    }
}
