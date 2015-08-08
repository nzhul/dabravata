using System.Web;
using System.Web.Optimization;

namespace Dabravata.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.IgnoreList.Clear();

            bundles.Add(new StyleBundle("~/bundles/main").Include(
                        "~/Content/luxen/css/bootstrap.min.css",
                        "~/Content/luxen/css/flexslider.css",
                        "~/Content/luxen/css/prettyPhoto.css",
                        "~/Content/luxen/css/datepicker.css",
                        "~/Content/luxen/css/selectordie.css",
                        "~/Content/luxen/css/2035-reset.css",
                        "~/Content/luxen/css/slicknav.css",
                        "~/Content/luxen/css/mainDabravata.css",
                        "~/Content/luxen/css/2035.responsive.css",
                        "~/Content/font-awesome.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/administration").Include(
                        "~/Content/luxen/css/bootstrap.min.css",
                        "~/Content/font-awesome.css",
                        "~/Content/administration.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/mainScripts").Include(
                        "~/Content/luxen/js/vendor/jquery-1.11.1.min.js",
                        "~/Content/luxen/js/vendor/bootstrap.min.js",
                        "~/Content/luxen/js/retina-1.1.0.min.js",
                        "~/Content/luxen/js/jquery.flexslider-min.js",
                        "~/Content/luxen/js/superfish.pack.1.4.1.js",
                        "~/Content/luxen/js/jquery.prettyPhoto.js",
                        "~/Content/luxen/js/bootstrap-datepicker.js",
                        "~/Content/luxen/js/selectordie.min.js",
                        "~/Content/luxen/js/jquery.slicknav.min.js",
                        "~/Content/luxen/js/jquery.parallax-1.1.3.js",
                        "~/Content/luxen/js/main.js"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
