using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace _2QXRunning
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapDateTimePicker").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/bootstrap-datetimepicker.js",
                        "~/Scripts/bootstrap-datetimepicker-fr.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinyMCE").Include(
                        "~/Scripts/tinymce/tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/duallistbox").Include(
                        "~/Scripts/jquery.bootstrap-duallistbox.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/2QXRunning").Include(
                        "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                        "~/Content/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/dataTables").Include(
                        "~/Content/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapDateTimePicker").Include(
                        "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                        "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/2QXRunning").Include(
                       "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/duallistbox").Include(
                       "~/Content/bootstrap-duallistbox.min.css"));
        }
    }
}
