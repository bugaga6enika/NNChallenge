using System.Threading.Tasks;
using NNChallenge.Interfaces;

namespace NNChallenge.Infrastructure.Contracts
{
    internal interface IWeatherForcastCacheRepository
    {
        public Task<IWeatherForcastVO?> GetAsync(WeatherForcastCacheKey cacheKey);
        public Task SetAsync(WeatherForcastCacheKey cacheKey, IWeatherForcastVO weatherForcast);
    }
}

