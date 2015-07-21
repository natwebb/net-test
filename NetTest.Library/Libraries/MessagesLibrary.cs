using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Library.Models;
using NetTest.Library.Translators;
using MessageCollection = NetTest.Business.Models.MessageCollection;

namespace NetTest.Library.Libraries
{
    public static class MessagesLibrary
    {
        private static readonly MessageCollection Messages = new MessageCollection();

        public static async Task<MessageDetailViewModel> CreateMessage(string content)
        {
            return await (await Messages.CreateAsync(content)).ToViewModelAsync();
        }

        public static async Task<bool> DeleteMessage(Guid id)
        {
            return await Messages.DeleteAsync(id);
        }

        public static async Task<IEnumerable<MessageDetailViewModel>> GetList()
        {
            return await (await Messages.GetAllAsync()).ToViewModelAsync();
        }

        public static async Task<MessageDetailViewModel> GetMessage(Guid id)
        {
            return await (await Messages.FindByIdAsync(id)).ToViewModelAsync();
        }

        public static async Task<MessageDetailViewModel> UpdateMessage(MessageDetailViewModel model)
        {
            return await (await Messages.UpdateAsync(model.Id, model.Content)).ToViewModelAsync();
        }
    }
}