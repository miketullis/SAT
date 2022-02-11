using System.Web.Optimization;

namespace SAT.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new Bundle("~/bundles/sitejs").Include(
                      "~/Content/assets/vendors/js/vendor.bundle.base.js",
                      //"~/Content/assets/vendors/chart.js/Chart.min.js",
                      //"~/Content/assets/vendors/progressbar.js/progressbar.min.js",
                      //"~/Content/assets/vendors/jvectormap/jquery-jvectormap.min.js",
                      //"~/Content/assets/vendors/jvectormap/jquery-jvectormap-world-mill-en.js",
                      //"~/Content/assets/vendors/owl-carousel-2/owl.carousel.min.js",
                      "~/Content/assets/js/off-canvas.js",
                      "~/Content/assets/js/hoverable-collapse.js",
                      "~/Content/assets/js/misc.js"
                      //"~/Content/assets/js/settings.js",
                      //"~/Content/assets/js/todolist.js",
                      //"~/Content/assets/js/dashboard.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/assets/vendors/mdi/css/materialdesignicons.min.css",
                      "~/Content/assets/vendors/css/vendor.bundle.base.css",
                      //"~/Content/assets/vendors/jvectormap/jquery-jvectormap.css",
                      //"~/Content/assets/vendors/flag-icon-css/css/flag-icon.min.css",
                      //"~/Content/assets/vendors/owl-carousel-2/owl.carousel.min.css",
                      //"~/Content/assets/vendors/owl-carousel-2/owl.theme.default.min.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/Site.css"));
            
        }
    }
}
