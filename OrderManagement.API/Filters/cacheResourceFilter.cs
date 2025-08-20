using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace OrderManagement.API.Filters;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class CacheResourceFilter : Attribute, IResourceFilter
{
    private readonly int _duration;
    
    public CacheResourceFilter(int duration) => _duration = duration;

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var logger = context.HttpContext.RequestServices.GetService<ILogger<CacheResourceFilter>>();
        var cacheKey = GenerateCacheKey(context.HttpContext.Request);
        var memoryCache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
        
        logger?.LogInformation("Cache check for key: {CacheKey}", cacheKey);
        
        if (memoryCache != null && memoryCache.TryGetValue(cacheKey, out var cachedResult))
        {
            logger?.LogInformation("Cache HIT for key: {CacheKey}", cacheKey);
            context.Result = cachedResult as IActionResult;
        }
        else
        {
            logger?.LogInformation("Cache MISS for key: {CacheKey}", cacheKey);
        }
    }
    
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        var logger = context.HttpContext.RequestServices.GetService<ILogger<CacheResourceFilter>>();
        
        if (context.Result is OkObjectResult okResult)
        {
            var cacheKey = GenerateCacheKey(context.HttpContext.Request);
            var memoryCache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            
            if (memoryCache != null)
            {
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_duration)
                };
                memoryCache.Set(cacheKey, okResult, cacheOptions);
                logger?.LogInformation("Cached result for key: {CacheKey} with duration: {Duration}s", cacheKey, _duration);
            }
        }
    }

    private string GenerateCacheKey(HttpRequest request)
    {
        var keyBuilder = new StringBuilder();
        keyBuilder.Append(request.Path);
        
        foreach (var param in request.Query.OrderBy(x => x.Key))
        {
            keyBuilder.Append($"_{param.Key}:{param.Value}");
        }
        
        return keyBuilder.ToString();
    }
}