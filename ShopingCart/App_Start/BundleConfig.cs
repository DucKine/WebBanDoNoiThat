using System.Web;
using System.Web.Optimization;

namespace ShopingCart
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            ScriptBundle scriptBundle = new ScriptBundle("~/bundles/javascript");

            scriptBundle.Include(
                "~/Asset/FrontEnd/js/vendor/jquery-1.12.0.min.js",
                "~/Asset/FrontEnd/js/bootstrap.min.js",
                "~/Asset/FrontEnd/js/ajax-mail.js",
                "~/Asset/FrontEnd/js/owl.carousel.min.js",
                "~/Asset/FrontEnd/js/jquery.nivo.slider.pack.js",
                "~/Asset/FrontEnd/js/plugins.js",
                "~/Asset/FrontEnd/js/main.js",
                "~/Asset/FrontEnd/js/jquery.validate.min.js"
                );

                       bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Asset/FrontEnd/css/bootstrap.min.css",
                        "~/Asset/FrontEnd/css/core.css",
                        "~/Asset/FrontEnd/css/shortcode/shortcodes.css",
                        "~/Asset/FrontEnd/style.css",
                        "~/Asset/FrontEnd/css/responsive.css",
                        "~/Asset/FrontEnd/css/custom.css",
                        "~/Asset/FrontEnd/css/about.css"
                        ));



            
        }
    }
}
