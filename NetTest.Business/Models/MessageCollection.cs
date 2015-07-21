using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Business.Contracts;
using NetTest.Persistence.Models;

namespace NetTest.Business.Models
{
    public class MessageCollection : IMessageCollection
    {
        private static readonly PersistenceMessageCollection Collection = new PersistenceMessageCollection();

        public async Task<IMessage> CreateAsync(string content)
        {
            var newMessage = await Collection.CreateAsync(Guid.NewGuid(), content);
            //TODO: replace below with a translator
            return new Message(Guid.Parse(newMessage.RowKey), newMessage.Content);
        }

        public async Task<IMessage> FindByIdAsync(Guid id)
        {
            var message = await Collection.FindByIdAsync(id);
            //TODO: replace below with a translator
            return new Message(Guid.Parse(message.RowKey), message.Content);
        }

        public async Task<IEnumerable<IMessage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}