using System.Web;
using System.Web.Optimization;

namespace MVC5_AngularJS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js",
                        "~/Scripts/jquery/jquery-migrate-1.2.1.js",
                        "~/Scripts/jquery/jquery.validate.js",
                        "~/Scripts/jquery/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery/jquery-ui-1.9.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jqueryui/jquery-ui.css",
                "~/Scripts/jqueryui/jquery-ui.theme.css"));

            #endregion

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            #region para jtable con bootstrap
            //bundles.Add(new StyleBundle("~/Content/css2").Include(
            //          "~/Content/bootstrap 2.0/bootstrap/bootstrap/css/bootstrap.css ",
            //          "~/Content/bootstrap 2.0/bootstrap/bootstrap/css/bootstrap-responsive.css"));

            //bundles.Add(new ScriptBundle("~/bundles/bootrapjs").Include(
            //   "~/Content/bootstrap 2.0/bootstrap/bootstrap/js/bootstrap.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
            //  "~/Scripts/jtable/jquery.jtable.bootstrap.js"));
            #endregion

            #region Angular js
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/AngularJs/angular.js",
                "~/Scripts/AngularJs/angular-route.js",
                "~/Scripts/AngularJs/angular-resource.js"));
            #endregion

            #region jtable bunbles

            bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
                "~/Scripts/jtable/jquery.jtable.js"));

            bundles.Add(new StyleBundle("~/Jtable/css").Include(
                "~/Scripts/jtable/themes/basic/jtable_basic.css",
                "~/Scripts/jtable/themes/jqueryui/jtable_jqueryui.css",
                "~/Scripts/jtable/themes/lightcolor/blue/jtable.css"));

            #endregion

            #region librerias js

            bundles.Add(new ScriptBundle("~/mainjs").Include("~/Scripts/Main.js"));

            bundles.Add(new ScriptBundle("~/bunbles/LibraryJS").Include("~/Scripts/back-to-top.js",
                "~/Scripts/Library/FlexSlide/jquery.flexslider.js",
                "~/Scripts/Library/PrettyPhoto/jquery.prettyPhoto.js",
                "~/Scripts/bootstrap-hover-dropdown.js",
                "~/Scripts/Library/jquery.placeholder.js",
                "~/Scripts/Library/jflickrfeed.js"));

            bundles.Add(new StyleBundle("~/bunbles/LibraryCss").Include(
                "~/Scripts/Library/PrettyPhoto/prettyPhoto.css",
                "~/ScriptsLibrary/FlexSlide/flexslider.css",
                "~/Content/font-awesome.css"));


            #endregion

        }
    }
}
