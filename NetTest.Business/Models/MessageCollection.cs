using System;
using System.Threading.Tasks;
using NetTest.Business.Contracts;

namespace NetTest.Business.Models
{
    public class MessageCollection : IMessageCollection
    {
        public async Task<IMessage> CreateAsync(string content)
        {
            return new Message { Content ="Hello", Id = Guid.NewGuid() };
        }

        public async Task<IMessage> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<System.Collections.Generic.IEnumerable<IMessage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}