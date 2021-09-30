using System;

namespace Cache.Redis.Console.Entidade
{
    public class Cliente
    {
        public Cliente(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
