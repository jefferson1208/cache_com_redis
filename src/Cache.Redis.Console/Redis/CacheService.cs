using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Cache.Redis.Console.Redis
{
    public class CacheService : ICacheService
    {
        private readonly ConnectionMultiplexer _connection;
        public CacheService()
        {
            _connection = ConnectionMultiplexer.Connect("connectionStringRedis");
        }
        public async Task<string> Buscar(string key)
        {
            var cache = _connection.GetDatabase();

            return await cache.StringGetAsync(key);
        }

        public async Task<bool> Deletar(string key)
        {
            var cache = _connection.GetDatabase();

            return await cache.KeyDeleteAsync(key);
        }

        public async Task<bool> Enviar(string key, string value, TimeSpan? expireIn = null)
        {
            var cache = _connection.GetDatabase();

            return await cache.StringSetAsync(key, value, expireIn);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
