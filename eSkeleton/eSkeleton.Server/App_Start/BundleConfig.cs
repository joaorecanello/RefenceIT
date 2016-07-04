using System.Web;
using System.Web.Optimization;

namespace LightSwitchApplication
{
    public class BundleConfig
    {

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/scripts/jquery-{version}.js",
                        "~/Content/scripts/jquery.unobtrusive-ajax.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                      "~/Content/scripts/template.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Content/scripts/particles.js",
                      "~/Content/scripts/nprogress.js",
                       "~/Content/scripts/notify.js",
                       "~/Content/scripts/bootstrap-toggle.js",
                      "~/Content/scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/account.login").Include(
                      "~/Content/scripts/Views/account.login.js"));

            bundles.Add(new StyleBundle("~/Content/home/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/animations.css",
                      "~/Content/css/home.css"));

            bundles.Add(new StyleBundle("~/Content/app/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/nprogress.css",
                      "~/Content/css/bootstrap-toggle.css",
                      "~/Content/css/app.css"));

        }

    }
}
