using Domain.Contracts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CacheRepository(IConnectionMultiplexer connection) : ICacheRepository
    {
        private readonly IDatabase _database = connection.GetDatabase();

        public async Task<string?> GetAsync(string cacheKey)
            => await _database.StringGetAsync(cacheKey);

        public async Task SetAsync(string cacheKey, string value, TimeSpan timeToLive)
            => await _database.StringSetAsync(cacheKey, value, timeToLive);
    }
}
