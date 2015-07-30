using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Business.Models;
using NetTest.Persistence.Entities;
using NetTest.Shared.Constants;
using NetTest.Shared.Tools;

namespace NetTest.Business.Translators
{
    public static class AssetEntityTranslatorExtensions
    {
        public static async Task<IEnumerable<Asset>> ToBusinessModelAsync(this IEnumerable<AssetEntity> entities)
        {
            return await TranslatorTools.ToViewModelAsync(entities, ToBusinessModelAsync);
        }

        public static async Task<Asset> ToBusinessModelAsync(this AssetEntity model)
        {
            if (model == null) return null;

            var businessModel = new Asset();
            await model.ExtrudeDetailInfo(businessModel);
            return businessModel;
        }

        private async static Task ExtrudeDetailInfo(this AssetEntity model, Asset businessModel)
        {
            businessModel.Id = Guid.Parse(model.RowKey);
            businessModel.Container = model.Container;
            businessModel.Owner = model.Owner;
            businessModel.Type = AssetTypesHelper.FromTypeString(model.Type);
            businessModel.Title = model.Title;
            businessModel.Url = new Uri(model.Url);
        }
    }
}