using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTest.Library.Translators
{
    public static class TranslatorTools
    {
        public static async Task<IEnumerable<TOut>> ToViewModelAsync<TIn, TOut, TContext>(IEnumerable<TIn> entities, TContext context, Func<TIn, TContext, Task<TOut>> translateAsyncFunc)
        {
            var list = new List<TOut>();
            var tasks = entities.Select(e => translateAsyncFunc.Invoke(e, context));
            list.AddRange(await Task.WhenAll(tasks));
            return list;
        }

        public static async Task<IEnumerable<TOut>> ToViewModelAsync<TIn, TOut>(IEnumerable<TIn> entities, Func<TIn, Task<TOut>> translateAsyncFunc)
        {
            var list = new List<TOut>();
            var tasks = entities.Select(translateAsyncFunc.Invoke);
            list.AddRange(await Task.WhenAll(tasks));
            return list;
        }
    }
}