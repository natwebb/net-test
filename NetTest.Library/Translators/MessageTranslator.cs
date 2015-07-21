using System.Collections.Generic;
using System.Threading.Tasks;
using NetTest.Business.Contracts;
using NetTest.Library.Models;

namespace NetTest.Library.Translators
{
    public static class MessageTranslatorExtensions
    {
        public static async Task<IEnumerable<MessageBasicViewModel>> ToBasicViewModelAsync(this IEnumerable<IMessage> entities)
        {
            return await TranslatorTools.ToViewModelAsync(entities, ToBasicViewModelAsync);
        }

        public static async Task<IEnumerable<MessageDetailViewModel>> ToViewModelAsync(this IEnumerable<IMessage> entities)
        {
            return await TranslatorTools.ToViewModelAsync(entities, ToViewModelAsync);
        }

        public static async Task<MessageBasicViewModel> ToBasicViewModelAsync(this IMessage model)
        {
            if (model == null) return null;

            var viewModel = new MessageBasicViewModel();
            await model.ExtrudeBasicInfo(viewModel);
            return viewModel;
        }

        public static async Task<MessageDetailViewModel> ToViewModelAsync(this IMessage model)
        {
            if (model == null) return null;

            var viewModel = new MessageDetailViewModel();
            await model.ExtrudeDetailInfo(viewModel);
            return viewModel;
        }

        private static async Task ExtrudeBasicInfo(this IMessage model, MessageBasicViewModel viewModel)
        {
            viewModel.Id = model.Id;
        }

        private static async Task ExtrudeDetailInfo(this IMessage model, MessageDetailViewModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Content = model.Content;
        }
    }
}