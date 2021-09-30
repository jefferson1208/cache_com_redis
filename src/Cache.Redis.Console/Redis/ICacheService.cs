using System;
using System.Threading.Tasks;

namespace Cache.Redis.Console.Redis
{
    public interface ICacheService : IDisposable
    {
        Task<bool> Enviar(string key, string value, TimeSpan? expireIn = null);
        Task<string> Buscar(string key);
        Task<bool> Deletar(string key);
    }
}
