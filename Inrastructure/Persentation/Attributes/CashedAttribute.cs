using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServicesAbstarction;
using System.Text;

namespace Persentation.Attributes
{
    public class CashedAttribute : Attribute, IAsyncActionFilter
    {
        private int _epriretime;

        public CashedAttribute(int epriretime)
        {
            _epriretime = epriretime;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IServiceManger>();
            var cacheKey = GenerateCacheKeyFromRequest(context);
            var cachedResponse = await cacheService.CashServices.GeTCashAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                context.Result = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                return;
            }
            var executedContext = await next();
            if (executedContext.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                await cacheService.CashServices.AddCashAsync(cacheKey, objectResult.Value, TimeSpan.FromMinutes(_epriretime));
            }
        }

        public string GenerateCacheKeyFromRequest(ActionExecutingContext context)
        {
            // Use This Methed To Generate A Unique Cache Key Based On The Request Path And Query Parameters
            var request = context.HttpContext.Request;
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
