using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NetTest.Business.Contracts
{
    public interface IAssetCollection
    {
        //Methods
        Task<IAsset> CreateAsync(string container, string type, string owner, string title, Stream stream);
        //Task<IMessage> FindByIdAsync(Guid id);
        //Task<IEnumerable<IMessage>> GetAllAsync();
    }
}