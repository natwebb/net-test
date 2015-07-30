using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NetTest.Persistence.Entities;

namespace NetTest.Persistence.Contracts
{
    public interface IPersistenceAssetCollection
    {
        //Methods
        Task<Uri> CreateBlobAsync(string container, string fileName, Stream fileStream);
        Task<AssetEntity> CreateTableEntityAsync(Guid id, string container, string type, string owner, string title, Uri url);
        //Task<ImageEntity> FindByIdAsync(Guid id);
        //Task<IEnumerable<ImageEntity>> GetAllAsync();
    }
}