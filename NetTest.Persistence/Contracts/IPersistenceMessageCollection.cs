using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Persistence.Entities;

namespace NetTest.Persistence.Contracts
{
    public interface IPersistenceMessageCollection
    {
        //Methods
        Task<MessageEntity> CreateAsync(Guid id, string content);
        Task<MessageEntity> FindByIdAsync(Guid id);
        Task<IEnumerable<MessageEntity>> GetAllAsync();
    }
}