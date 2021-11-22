using System.Web;
using System.Web.Optimization;

namespace PresentacionMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Clock").Include(
                    "~/Scripts/Clock.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapa").Include(
                    "~/Scripts/Mapas/MapaComun.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapaPoligonos").Include(
                    "~/Scripts/Mapas/MapaPoligonos.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapaCargado").Include(
                    "~/Scripts/Mapas/MapaPoligonosCargado.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapaEnvios").Include(
                "~/Scripts/Mapas/MapaParaEnvios.js"));
        }
    }
}
