using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Business.Models;
using NetTest.Persistence.Entities;
using NetTest.Shared.Tools;

namespace NetTest.Business.Translators
{
    public static class MessageEntityTranslatorExtensions
    {
        public static async Task<IEnumerable<Message>> ToBusinessModelAsync(this IEnumerable<MessageEntity> entities)
        {
            return await TranslatorTools.ToViewModelAsync(entities, ToBusinessModelAsync);
        }

        public static async Task<Message> ToBusinessModelAsync(this MessageEntity model)
        {
            if (model == null) return null;

            var businessModel = new Message();
            await model.ExtrudeDetailInfo(businessModel);
            return businessModel;
        }

        private async static Task ExtrudeDetailInfo(this MessageEntity model, Message businessModel)
        {
            businessModel.Id = Guid.Parse(model.RowKey);
            businessModel.Content = model.Content;
        }
    }
}