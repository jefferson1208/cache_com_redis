using Cache.Redis.Console.Entidade;
using Cache.Redis.Console.Redis;
using System;
using System.Text.Json;

namespace Cache.Redis.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            EnviarParaRedis();
        }

        static void EnviarParaRedis()
        {
            ICacheService cache = new CacheService();

            var cliente1 = new Cliente("Jeferson");
            var cliente2 = new Cliente("Carlos");
            var cliente3 = new Cliente("Fernando");
            var cliente4 = new Cliente("Paulo");

            cache.Enviar(key: cliente1.Id.ToString(), value: ConverterParaJson(cliente1), expireIn: TimeSpan.FromSeconds(10));
            cache.Enviar(key: cliente1.Id.ToString(), value: ConverterParaJson(cliente2), expireIn: TimeSpan.FromSeconds(10));
            cache.Enviar(key: cliente1.Id.ToString(), value: ConverterParaJson(cliente3), expireIn: TimeSpan.FromSeconds(10));
            cache.Enviar(key: cliente1.Id.ToString(), value: ConverterParaJson(cliente4), expireIn: TimeSpan.FromSeconds(10));
           
        }

        static string ConverterParaJson(Cliente cliente)
        {
            return JsonSerializer.Serialize(cliente);
        }

    }
}
