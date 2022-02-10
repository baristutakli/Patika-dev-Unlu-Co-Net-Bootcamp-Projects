using BarisTutakli.Week4.WebApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Week4.WebApi.Services.Abstract
{
    public interface IDisributedCacheRedisService
    {
        Task<Byte[]> GetCachedProducts(string newKey);
        Task SetProductsToCache(string newKey, List<Product> items, DistributedCacheEntryOptions options);
    }
}
