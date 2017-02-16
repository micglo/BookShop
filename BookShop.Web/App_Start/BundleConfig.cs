using System.Web.Optimization;

namespace BookShop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                      "~/Scripts/select2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/zocial.css",
                      "~/Content/tooltip.css",
                      "~/Content/css/select2.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                      "~/Content/jquery-ui.css",
                      "~/Content/jquery-ui.structure.css",
                      "~/Content/jquery-ui.theme.css"));

            //myScripts
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/myScripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/commonBooks").Include(
                        "~/Scripts/myScripts/commonBooks.js"));

            bundles.Add(new ScriptBundle("~/bundles/cart").Include(
                        "~/Scripts/myScripts/cart.js"));

            bundles.Add(new ScriptBundle("~/bundles/removeLogins").Include(
                        "~/Scripts/myScripts/removeLogins.js"));

            bundles.Add(new ScriptBundle("~/bundles/spinnerTabs").Include(
                        "~/Scripts/myScripts/spinnerTabs.js"));

            bundles.Add(new ScriptBundle("~/bundles/openAuthorReviewModals").Include(
                        "~/Scripts/myScripts/openAuthorReviewModals.js"));

            bundles.Add(new ScriptBundle("~/bundles/openBookReviewModals").Include(
                        "~/Scripts/myScripts/openBookReviewModals.js"));

            bundles.Add(new ScriptBundle("~/bundles/openPublishingReviewModals").Include(
                        "~/Scripts/myScripts/openPublishingReviewModals.js"));

            bundles.Add(new ScriptBundle("~/bundles/myReviews").Include(
                        "~/Scripts/myScripts/myReviews.js"));

            bundles.Add(new ScriptBundle("~/bundles/author").Include(
                        "~/Scripts/myScripts/author.js"));

            bundles.Add(new ScriptBundle("~/bundles/singleBook").Include(
                        "~/Scripts/myScripts/singleBook.js"));

            bundles.Add(new ScriptBundle("~/bundles/publishing").Include(
                        "~/Scripts/myScripts/publishing.js"));

            bundles.Add(new ScriptBundle("~/bundles/tooltip").Include(
                        "~/Scripts/myScripts/tooltip.js"));

            bundles.Add(new ScriptBundle("~/bundles/updateMyProfileData").Include(
                        "~/Scripts/myScripts/updateMyProfileData.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesDefault").Include(
                        "~/Scripts/myScripts/dataTablesDefault.js"));

            bundles.Add(new ScriptBundle("~/bundles/deliveryData").Include(
                        "~/Scripts/myScripts/deliveryData.js")); 

            bundles.Add(new ScriptBundle("~/bundles/transactionsIndex").Include(
                        "~/Scripts/myScripts/transactionsIndex.js")); 

            bundles.Add(new ScriptBundle("~/bundles/adminTransactionDetails").Include(
                        "~/Scripts/myScripts/adminTransactionDetails.js")); 

            bundles.Add(new ScriptBundle("~/bundles/adminAuthorIndex").Include(
                        "~/Scripts/myScripts/adminAuthorIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminPublishingIndex").Include(
                        "~/Scripts/myScripts/adminPublishingIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminBookIndex").Include(
                        "~/Scripts/myScripts/adminBookIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker-pl").Include(
                        "~/Scripts/ui.datepicker-pl.js",
                        "~/Scripts/i18n/pl.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2Default").Include(
                        "~/Scripts/myScripts/select2Default.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminBookForm").Include(
                        "~/Scripts/myScripts/adminBookForm.js"));
        }
    }
}
