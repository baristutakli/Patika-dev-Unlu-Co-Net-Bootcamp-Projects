using BarisTutakli.Week4.WebApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarisTutakli.Week4.WebApi.Services.Abstract
{
    public class RedisCacheService : IDisributedCacheRedisService
    {
        private readonly IDistributedCache _distributedCache;
        public RedisCacheService( IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<byte[]> GetCachedProducts(string newKey)
        {
            var cachedItem = await _distributedCache.GetAsync(newKey);
            return cachedItem;
            
        }

        public async Task SetProductsToCache(string newKey, List<Product> items, DistributedCacheEntryOptions options)
        {
           await _distributedCache.SetAsync(newKey, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(items)), options);
        }
    }
}
