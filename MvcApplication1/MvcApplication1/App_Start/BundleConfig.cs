using System.Web;
using System.Web.Optimization;

namespace MvcApplication1
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));
                    
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/javaScriptFile/js").Include(
                        "~/Scripts/javaScriptFile/calendario1.js", "~/Scripts/javaScriptFile/colorpicker.js",
                        "~/Scripts/javaScriptFile/eye.js", "~/Scripts/javaScriptFile/jquery.qtip-1.0.0-rc3.min.js",
                        "~/Scripts/javaScriptFile/jquery.qtip-1.0.js", "~/Scripts/javaScriptFile/jquery.qtip-1.0.min.js",
                        "~/Scripts/javaScriptFile/jquery-1.4.2.js", "~/Scripts/javaScriptFile/jquery-1.4.2.min.js",
                        "~/Scripts/javaScriptFile/jquery-1.4.2-ie-fix.js", "~/Scripts/javaScriptFile/jquery-1.4.2-ie-fix.min.js",
                        "~/Scripts/javaScriptFile/jquery-frontier-cal-1.3.2.js", "~/Scripts/javaScriptFile/jquery-frontier-cal-1.3.2.min.js",
                        "~/Script   s/javaScriptFile/jquery-ui-1.8.1.custom.min.js", "~/Scripts/javaScriptFile/jquery-ui-1.8.2.custom.min.js",
                        "~/Scripts/javaScriptFile/jshashtable-2.1.js", "~/Scripts/javaScriptFile/layout.js", "~/Scripts/javaScriptFile/utils.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

           

           

            bundles.Add(new StyleBundle("~/Content/colorpicker/css").Include("~/Content/colorpicker/colorpicker.css","~/Content/colorpicker/layout.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui/smoothness/css").Include("~/Content/jquery-ui/smoothness/jquery-ui-1.8.1.custom.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui/flick/css").Include("~/Content/jquery-ui/flick/jquery-ui-1.8.2.custom.css"));

            bundles.Add(new StyleBundle("~/Content/styles/css").Include("~/Content/styles/base.css", "~/Content/styles/jquery.fancybox-1.3.4.css", "~/Content/styles/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/styles/scripts").Include(                      
                        "~/Scripts/scripts/jquery.pikachoose"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                       "~/Content/themes/base/jquery.ui.accordion.css",
                       "~/Content/themes/base/jquery.ui.all.css",
                       "~/Content/themes/base/jquery.ui.autocomplete.css",
                       "~/Content/themes/base/jquery.ui.base.css",
                       "~/Content/themes/base/jquery.ui.button.css",
                       "~/Content/themes/base/jquery.ui.core.css",
                       "~/Content/themes/base/jquery.ui.datepicker.css",
                       "~/Content/themes/base/jquery.ui.dialog.css",
                       "~/Content/themes/base/jquery.ui.progressbar.css",
                       "~/Content/themes/base/jquery.ui.resizable.css",
                       "~/Content/themes/base/jquery.ui.selectable.css",
                       "~/Content/themes/base/jquery.ui.slider.css",
                       "~/Content/themes/base/jquery.ui.tabs.css",
                       "~/Content/themes/base/jquery.ui.theme.css",
                       "~/Content/themes/base/jquery-ui.css"));

  
        }
    }
}