using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using NetTest.Library.Libraries;

namespace NetTest.UI.Code.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index(Guid id)
        {
            return await ProcessResult(() => MessagesLibrary.GetMessage(id));
        }

        [HttpPost]
        public async Task<ActionResult> Index(string content)
        {
            return await ProcessResult(() => MessagesLibrary.CreateMessage(content));
        } 
    }
}