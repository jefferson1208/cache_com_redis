# Utilizando Cache com Redis
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 1 - Pacotes

```bash
Install-Package StackExchange.Redis

```

## 2 - Interface
```csharp
public interface ICacheService : IDisposable
{
      Task<bool> Enviar(string key, string value, TimeSpan? expireIn = null);
      Task<string> Buscar(string key);
      Task<bool> Deletar(string key);
}
```

## 2 - Implementação classe concreta implementando a interface acima "ICacheService"

```csharp
public class CacheService : ICacheService
{
}
```

### Construtor
```csharp
private readonly ConnectionMultiplexer _connection;

public CacheService()
{
     _connection = ConnectionMultiplexer.Connect("connectionStringRedis");
}
```
### Salvar cache

```csharp
public async Task<bool> Enviar(string key, string value, TimeSpan? expireIn = null)
{
      var cache = _connection.GetDatabase();

      return await cache.StringSetAsync(key, value, expireIn);
 }
```

#### Obs >> expireIn: Tempo que o dado permanecerá em cache.

### Buscar dado em cache

```csharp
public async Task<string> Buscar(string key)
{
     var cache = _connection.GetDatabase();

     return await cache.StringGetAsync(key);
}
```

### Remover dado em cache

```csharp
public async Task<bool> Deletar(string key)
{
     var cache = _connection.GetDatabase();

     return await cache.KeyDeleteAsync(key);
}
```

### Dispose

```csharp
public void Dispose()
{
    _connection?.Dispose();
}
```

## 3 - Tecnologias
<div style="display: inline_block"><br>
  <img align="center" alt="Jeferson-Netcore" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg">
  <img align="center" alt="Jeferson-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
</div>
