using System.IO;
using System.Threading.Tasks;
using NetTest.Business.Models;
using NetTest.Library.Models;
using NetTest.Library.Translators;

namespace NetTest.Library.Libraries
{
    public static class AssetsLibrary
    {
        private static readonly AssetCollection Assets = new AssetCollection();

        public static async Task<AssetDetailViewModel> CreateAsset(string container, string type, string owner, string title, Stream stream)
        {
            return await (await Assets.CreateAsync(container, type, owner, title, stream)).ToViewModelAsync();
        }
    }
}