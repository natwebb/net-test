using System;
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

        public static async Task<MessageDetailViewModel> GetMessage(Guid id)
        {
            return await (await Messages.FindByIdAsync(id)).ToViewModelAsync();
        }
    }
}