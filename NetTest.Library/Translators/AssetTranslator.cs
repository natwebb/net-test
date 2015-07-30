using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Business.Contracts;
using NetTest.Library.Models;
using NetTest.Shared.Constants;
using NetTest.Shared.Tools;

namespace NetTest.Library.Translators
{
    public static class AssetTranslatorExtensions
    {
        public static async Task<IEnumerable<AssetBasicViewModel>> ToBasicViewModelAsync(this IEnumerable<IAsset> entities)
        {
            return await TranslatorTools.ToViewModelAsync(entities, ToBasicViewModelAsync);
        }

        public static async Task<IEnumerable<AssetDetailViewModel>> ToViewModelAsync(this IEnumerable<IAsset> entities)
        {
            return await TranslatorTools.ToViewModelAsync(entities, ToViewModelAsync);
        }

        public static async Task<AssetBasicViewModel> ToBasicViewModelAsync(this IAsset model)
        {
            if (model == null) return null;

            var viewModel = new AssetBasicViewModel();
            await model.ExtrudeBasicInfo(viewModel);
            return viewModel;
        }

        public static async Task<AssetDetailViewModel> ToViewModelAsync(this IAsset model)
        {
            if (model == null) return null;

            var viewModel = new AssetDetailViewModel();
            await model.ExtrudeDetailInfo(viewModel);
            return viewModel;
        }

        private static async Task ExtrudeBasicInfo(this IAsset model, AssetBasicViewModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Url = model.Url;
        }

        private static async Task ExtrudeDetailInfo(this IAsset model, AssetDetailViewModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Url = model.Url;
            viewModel.Container = model.Container;
            viewModel.Owner = model.Owner;
            viewModel.Title = model.Title;
            viewModel.Type = model.Type.ToTypeString();
        }
    }
}