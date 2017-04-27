using System.Web;
using System.Web.Optimization;

namespace ASACreateLicense.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Assets/admin/libs/jquery/jquery.min.js",
            //            "~/Assets/admin/libs/bootstrap/bootstrap.js",
            //            "~/Assets/admin/libs/slimScroll/jquery.slimscroll.min.js",
            //            "~/Assets/admin/libs/fastclick/fastclick.js",
            //            "~/Assets/admin/js/app.min.js",
            //            "~/Assets/admin/js/datepicker/bootstrap-datepicker.min.js"
            //            ));

            //BundleTable.EnableOptimizations = true;


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
