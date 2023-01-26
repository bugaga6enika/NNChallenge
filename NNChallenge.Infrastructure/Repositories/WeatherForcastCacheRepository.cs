using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using NNChallenge.Infrastructure.Contracts;
using NNChallenge.Interfaces;

namespace NNChallenge.Infrastructure.Repositories
{
    internal class WeatherForcastCacheRepository : IWeatherForcastCacheRepository
    {
        private readonly ConcurrentDictionary<string, IWeatherForcastVO> _cache = new ConcurrentDictionary<string, IWeatherForcastVO>();

        public WeatherForcastCacheRepository()
        {
        }

        public Task<IWeatherForcastVO?> GetAsync(WeatherForcastCacheKey cacheKey)
        {
            if (_cache.TryGetValue(cacheKey, out var result) && result != null)
            {
                return Task.FromResult(result);
            }

            return Task.FromResult<IWeatherForcastVO?>(null);
        }

        public Task SetAsync(WeatherForcastCacheKey cacheKey, IWeatherForcastVO weatherForcast)
        {
            _ = cacheKey ?? throw new ArgumentNullException(nameof(cacheKey));
            _ = weatherForcast ?? throw new ArgumentNullException(nameof(weatherForcast));

            _cache.AddOrUpdate(cacheKey, weatherForcast, (key, oldValue) => weatherForcast);

            return Task.CompletedTask;
        }
    }
}

