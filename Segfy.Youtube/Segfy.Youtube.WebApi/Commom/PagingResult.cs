using Microsoft.AspNetCore.Mvc;
using Segfy.Youtube.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segfy.Youtube.WebApi.Commom
{
    public class PagingResult<T> : ActionResult
    {
        private readonly IPagingQueryParams p;
        private readonly Task<IEnumerable<T>> result;
        private readonly Task<long> count;

        public PagingResult(IPagingQueryParams p, Task<IEnumerable<T>> result, Task<long> count)
        {
            this.p = p;
            this.result = result;
            this.count = count;
        }

        public async override Task ExecuteResultAsync(ActionContext context)
        {
            await Task.WhenAll(result, count);

            var dataResult = await result;
            var dataCount = await count;

            var obj = new ObjectResult(new
            {
                page = p.Page ?? 1,
                count = dataCount,
                items = dataResult,
            });

            await obj.ExecuteResultAsync(context);
        }
    }
}
