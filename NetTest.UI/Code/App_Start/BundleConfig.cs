using System.Web.Optimization;
using NetTest.UI.Code.Extensions;

namespace NetTest.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            ConfigureScripts(bundles);
            ConfigureStyles(bundles);
        }

        public static void ConfigureScripts(BundleCollection bundles)
        {
            //Vendor Scripts
            var jquery = new ScriptBundle("~/bundles/vendor/jquery");
            jquery.Include(
                        "~/Content/vendor/scripts/jquery/jquery-2.1.4.js");
            bundles.Add(jquery);

            var vendorAngular = new ScriptBundle("~/bundles/vendor/angular");
            vendorAngular.Include(
                      "~/Content/vendor/scripts/angular/angular-1.4.3.js",
                      "~/Content/vendor/scripts/angular/angular-ui-router.js",
                      "~/Content/vendor/scripts/angular/angular-cookies.js");
            bundles.Add(vendorAngular);

            //App Scripts
            var coreAngular = new ScriptBundle("~/bundles/app/coreangular");
            coreAngular.Include(
                "~/Content/app/common/scripts/core/app.js",
                "~/Content/app/common/scripts/core/app.config.js",
                "~/Content/app/common/scripts/core/app.run.js",
                "~/Content/app/common/scripts/core/core.js"
            );
            coreAngular.SearchDirectories(
                "~/Content/app/common/scripts/core/stateConfig"
            );
            bundles.Add(coreAngular);

            var commonAngular = new ScriptBundle("~/bundles/app/commonangular");
            commonAngular.SearchDirectories(
                "~/Content/app/common/scripts/constants",
                "~/Content/app/common/scripts/controllers",
                "~/Content/app/common/scripts/factories",
                "~/Content/app/common/scripts/filters",
                "~/Content/app/common/scripts/providers",
                "~/Content/app/common/scripts/services"
            );
            bundles.Add(commonAngular);

            var functionalAngular = new ScriptBundle("~/bundles/app/functionalangular");
            functionalAngular.SearchDirectories(
                "~/Content/app/home"
            );
            bundles.Add(functionalAngular);
        }

        public static void ConfigureStyles(BundleCollection bundles)
        {
            var css = new StyleBundle("~/bundles/css");
            css.Include();
            bundles.Add(css);
        }
    }
}
