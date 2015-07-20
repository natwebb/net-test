using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Optimization;
using WebGrease.Css.Extensions;

namespace NetTest.UI.Code.Extensions
{
    public static class BundleExtensions
    {
        readonly static string appPath = HostingEnvironment.MapPath("~/");
        readonly static string[] customExclusions = { ".scss", ".css" };
        readonly static string[] extExclusions = { ".txt", ".map", ".cshtml", ".png", ".jpg" };

        public static void SearchDirectories(this Bundle bundles, string path)
        {
            bundles.Include(GetBundleReferences(path));
        }

        public static void SearchDirectories(this Bundle bundles, params string[] paths)
        {
            paths.ForEach(path => bundles.Include(GetBundleReferences(path)));
        }
        
        private static string[] GetBundleReferences(string path)
        {
            var paths = new List<string>();

            if (path.StartsWith("~/"))
            {
                path = path.Substring(2);
            }
            path = Path.Combine(appPath, path);

            var folder = new DirectoryInfo(path);
            if (folder.Exists)
            {
                if (folder.GetFiles().Any())
                {
                    string[] exclusions = extExclusions;
                    if (customExclusions != null)
                    {
                        exclusions = extExclusions.Concat(customExclusions).ToArray();
                    }

                    var files = folder.GetFiles().Where(f => !exclusions.Contains(f.Extension.ToLower()));
                    paths.AddRange(files.Select(file => GetVirtualPath(file.FullName)));
                }

                if (folder.GetDirectories().Any())
                {
                    paths.AddRange(folder.GetDirectories().SelectMany(d => GetBundleReferences(d.FullName)));
                }
            }
            return paths.ToArray();
        }

        private static string GetVirtualPath(string absPath)
        {
            return absPath.Substring(appPath.Length).Replace('\\', '/').Insert(0, "~/");
        }
    }
}