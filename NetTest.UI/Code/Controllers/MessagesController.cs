using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using NetTest.Library.Libraries;
using NetTest.Library.Models;

namespace NetTest.UI.Code.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All()
        {
            return await ProcessResult(MessagesLibrary.GetList);
        }
            
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

        [HttpPut]
        public async Task<ActionResult> Update(MessageDetailViewModel model)
        {
            return await ProcessResult(() => MessagesLibrary.UpdateMessage(model));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await ProcessResult(() => MessagesLibrary.DeleteMessage(id));
        }
    }
}