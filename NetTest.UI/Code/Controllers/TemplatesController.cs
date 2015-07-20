using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NC2.CPM.Admin.Shared.Controllers
{
    public class TemplatesController : Controller
    {
        public virtual async Task<ActionResult> Fetch(string id)
        {
            id = string.Concat("-", id);
            return PartialView(await GetPathAsync(id));
        }

        #region Helper functions
        private static async Task<string> GetPathAsync(string path)
        {
            try
            {
                var sb = new StringBuilder();
                var parts = new Queue<string>(path.Split('-'));

                if (string.IsNullOrEmpty(parts.Peek()))
                {
                    parts.Dequeue(); // Toss the initial null element.
                }

                sb.Append("~/Content/app");
                while (parts.Count > 0)
                {
                    sb.Append(string.Concat("/", parts.Dequeue()));
                }
                sb.Append(".cshtml");
                return sb.ToString();
            }
            catch
            {
                //TODO: is there actually any way to get this to fire?
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, "Template {0} not found.", path));
            }
        }
        #endregion Helper functions
    }
}