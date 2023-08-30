using System.Web;
using System.Web.Optimization;

namespace JuegoOlimpico.Web
{
    public class BundleConfig
    {
     
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

       
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                  "~/Scripts/app/funciones.generales.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/login").Include(
            "~/Content/css/login.css",
            "~/Content/css/Modal.css",
            "~/Content/css/Normalize.css"));

            //PLUGINS

            //bundles.Add(new ScriptBundle("~/bundles/Plugins/css").Include(
            //            "~/Content/datatable/css/jquery.dataTables.min.css",
            //            "~/Content/datatable/css/responsive.dataTables.min.css",
            //            "~/Content/datatable/css/buttons.dataTables.min.css",
            //            "~/Content/fontawesome/css/all.css"
            //            ));
            //bundles.Add(new ScriptBundle("~/bundles/Plugins/js").Include(
            //            "~/Content/datatable/js/jquery.dataTables.min.js",
            //            "~/Content/datatable/js/dataTables.responsive.min.js",
            //            "~/Content/datatable/js/dataTables.buttons.min.js",
            //            "~/Content/fontawesome/js/all.js"
            //            ));


        }
    }
}
