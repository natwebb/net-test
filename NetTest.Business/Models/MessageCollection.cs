using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Business.Contracts;
using NetTest.Business.Translators;
using NetTest.Persistence.Models;

namespace NetTest.Business.Models
{
    public class MessageCollection : IMessageCollection
    {
        private static readonly PersistenceMessageCollection Collection = new PersistenceMessageCollection();

        public async Task<IMessage> CreateAsync(string content)
        {
            return await (await Collection.CreateAsync(Guid.NewGuid(), content)).ToBusinessModelAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await Collection.DeleteAsync(id);
        }

        public async Task<IMessage> FindByIdAsync(Guid id)
        {
            return await (await Collection.FindByIdAsync(id)).ToBusinessModelAsync();
        }

        public async Task<IEnumerable<IMessage>> GetAllAsync()
        {
            return await (await Collection.GetAllAsync()).ToBusinessModelAsync();
        }

        public async Task<IMessage> UpdateAsync(Guid id, string content)
        {
            return await (await Collection.UpdateAsync(id, content)).ToBusinessModelAsync();
        } 
    }
}