using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetTest.Business.Contracts
{
    public interface IMessageCollection
    {
        //Methods
        Task<IMessage> CreateAsync(string content);
        Task<IMessage> FindByIdAsync(Guid id);
        Task<IEnumerable<IMessage>> GetAllAsync();
    }
}