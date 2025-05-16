using Domain.Contracts;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class CacheService(ICacheRepository cacheRepository) : ICacheService
    {
        public async Task<string?> GetAsync(string cacheKey)
            => await cacheRepository.GetAsync(cacheKey);

        public async Task SetAsync(string cacheKey, object value, TimeSpan timeToLive)
        {
            var serializedObj = JsonSerializer.Serialize(value);
            await cacheRepository.SetAsync(cacheKey, serializedObj, timeToLive);
        }
    }
}
