using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Services;

namespace Talabat.Service
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task CachResponseAsync(string cachKey, object response, TimeSpan timeToLive)
        {
            if (response == null) return;

            var option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var serializedResponse = JsonSerializer.Serialize(response, option);
            await _database.StringSetAsync(cachKey, serializedResponse, timeToLive);
        }

        public async Task<string> GetCachedResponseAsync(string cachKey)
        {
            var cachedResponse = await _database.StringGetAsync(cachKey);

            if (cachedResponse.IsNullOrEmpty) return null;

            return cachedResponse;
        }
    }
}
