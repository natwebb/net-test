using System;
using System.Threading.Tasks;
using NetTest.Library.Models;
using MessageCollection = NetTest.Business.Models.MessageCollection;

namespace NetTest.Library.Libraries
{
    public static class MessagesLibrary
    {
        private static readonly MessageCollection Messages;

        public static async Task<MessageDetailViewModel> CreateMessage(string content)
        {
            return await Messages.CreateAsync(content).ToViewModel();
        } 

        public static async Task<MessageDetailViewModel> GetMessage(Guid id)
        {
            MessageDetailViewModel m = new MessageDetailViewModel{ Content = "Hello", Id = id };
            return m;
        }
    }
}