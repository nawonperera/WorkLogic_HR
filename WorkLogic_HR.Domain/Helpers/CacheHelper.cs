using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkLogic_HR.Core.Helpers;

public class CacheHelper
{
    private readonly IMemoryCache _cache;

    public CacheHelper(IMemoryCache cache)
    {
        _cache = cache;
    }

    public T CacheLong<T>(string cacheKey, Func<T> dataRetrievalFunc)
    {
        if (!_cache.TryGetValue(cacheKey, out T? cacheResult) || cacheResult == null)
        {
            cacheResult = dataRetrievalFunc();

            var cacheOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);

            _cache.Set(cacheKey, cacheResult, cacheOptions);
        }
        return cacheResult;
    }

    public T Cached<T>(string cacheKey, Func<T> dataRetrievalFunc)
    {
        if (!_cache.TryGetValue(cacheKey, out T? cacheResult) || cacheResult == null)
        {
            cacheResult = dataRetrievalFunc();

            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)).SetPriority(CacheItemPriority.Normal);

            _cache.Set(cacheKey, cacheResult, cacheOptions);
        }
        return cacheResult;
    }

    public void RemoveCache(string cacheKey)
    {
        _cache.Remove(cacheKey);
    }
}
