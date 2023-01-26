using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using NNChallenge.Infrastructure.Contracts;
using NNChallenge.Interfaces;

namespace NNChallenge.Infrastructure.Repositories
{
    internal class WeatherForcastRepository : IWeatherForcastRepository
    {
        private readonly IWeatherForcastCacheRepository _weatherForcastCacheRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly IDictionary<string, string> DefaultQueryParams = new Dictionary<string, string>()
        {
            { "key" , "898147f83a734b7dbaa95705211612" },
            { "aqi", "no" },
            { "alerts", "no" }
        };

        public WeatherForcastRepository(IWeatherForcastCacheRepository weatherForcastCacheRepository, IHttpClientFactory httpClientFactory)
        {
            _weatherForcastCacheRepository = weatherForcastCacheRepository ?? throw new ArgumentNullException(nameof(weatherForcastCacheRepository));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IWeatherForcastVO> GetAsync(IWeatherForcastRequest weatherForcastRequest, CancellationToken cancellationToken = default)
        {
            _ = weatherForcastRequest ?? throw new ArgumentNullException(nameof(weatherForcastRequest));

            var cacheKey = new WeatherForcastCacheKey(weatherForcastRequest.City, DateTime.Now);
            var cachedResult = await _weatherForcastCacheRepository.GetAsync(cacheKey);

            if (cachedResult != null)
            {
                return cachedResult;
            }

            using var httpClient = _httpClientFactory.Create();

            var uri = GenerateUri(weatherForcastRequest);

            var responseMessage = await httpClient.GetAsync(uri, cancellationToken);

            responseMessage.EnsureSuccessStatusCode();
            var responseAsString = await responseMessage.Content.ReadAsStringAsync();

            var weatherForcast = JsonConvert.DeserializeObject<ForcastRoot>(responseAsString);

            var result = new Contracts.WeatherForcast(weatherForcast);

            await _weatherForcastCacheRepository.SetAsync(cacheKey, result);

            return result;
        }

        private string GenerateUri(IWeatherForcastRequest weatherForcastRequest)
        {
            _ = weatherForcastRequest ?? throw new ArgumentNullException(nameof(weatherForcastRequest));

            var uriBuilder = new UriBuilder("https://api.weatherapi.com/v1/forecast.json");

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var keyValuePair in DefaultQueryParams)
            {
                query[keyValuePair.Key] = keyValuePair.Value;
            }
            query["q"] = weatherForcastRequest.City;
            query["days"] = weatherForcastRequest.ForecastWindow.ToString();

            uriBuilder.Query = query.ToString();

            return uriBuilder.ToString();
        }
    }
}

