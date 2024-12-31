namespace DemoRedis.Services
{
    public interface IResponseCacheService
    {
        Task SetCacheRepsonseAsync(string cacheKey, object reponse, TimeSpan timeout);

        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}
