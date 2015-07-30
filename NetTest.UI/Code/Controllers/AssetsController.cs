using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NetTest.Library.Libraries;
using NetTest.Library.Models;

namespace NetTest.UI.Code.Controllers
{
    public class AssetsController : BaseController
    {
        //[HttpGet]
        //public async Task<ActionResult> All()
        //{
        //    return await ProcessResult(MessagesLibrary.GetList);
        //}
            
        //[HttpGet]
        //public async Task<ActionResult> Index(Guid id)
        //{
        //    return await ProcessResult(() => MessagesLibrary.GetMessage(id));
        //}

        [HttpPost]
        public async Task<ActionResult> Index(AssetDetailViewModel model, HttpPostedFileBase file)
        {
            return await ProcessResult(() => AssetsLibrary.CreateAsset(model.Container, model.Type, model.Owner, file.FileName, file.InputStream));
        }

        //[HttpPut]
        //public async Task<ActionResult> Update(MessageDetailViewModel model)
        //{
        //    return await ProcessResult(() => MessagesLibrary.UpdateMessage(model));
        //}

        //[HttpDelete]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    return await ProcessResult(() => MessagesLibrary.DeleteMessage(id));
        //}
    }
}