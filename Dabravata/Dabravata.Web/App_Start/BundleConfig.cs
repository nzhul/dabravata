using System.Web;
using System.Web.Optimization;

namespace Dabravata.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Default Configs
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            // Luxen Configs

            bundles.Add(new StyleBundle("~/bundles/main").Include(
                        "~/Content/luxen/css/bootstrap.min.css",
                        "~/Content/luxen/css/flexslider.css",
                        "~/Content/luxen/css/prettyPhoto.css",
                        "~/Content/luxen/css/datepicker.css",
                        "~/Content/luxen/css/selectordie.css",
                        "~/Content/luxen/css/2035-reset.css",
                        "~/Content/luxen/css/slicknav.css",
                        "~/Content/luxen/css/mainDabravata.css",
                        "~/Content/luxen/css/2035.responsive.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/administration").Include(
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

            bundles.IgnoreList.Clear();
        }
    }
}
