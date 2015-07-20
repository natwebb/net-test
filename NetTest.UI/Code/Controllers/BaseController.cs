using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace NetTest.UI.Code.Controllers
{
    public class BaseController : Controller
    {
        public async Task<ActionResult> ProcessResult<TReturn>(Func<Task<TReturn>> func)
        {
            var ret = await Task.Run(() => func.Invoke()).ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(ret);
            return Content(json, "application/json");
        } 
    }
}