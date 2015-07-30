using System.IO;
using System.Threading.Tasks;
using NetTest.Business.Contracts;
using NetTest.Business.Translators;
using NetTest.Persistence.Models;

namespace NetTest.Business.Models
{
    public class AssetCollection : IAssetCollection
    {
        private static readonly PersistenceAssetCollection Collection = new PersistenceAssetCollection();

        public async Task<IAsset> CreateAsync(string container, string type, string owner, string title, Stream stream)
        {
            return await (await Collection.CreateAsync(container, type, owner, title, stream)).ToBusinessModelAsync();
        }
    }
}