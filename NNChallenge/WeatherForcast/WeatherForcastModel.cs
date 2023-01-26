using System;
using System.Threading.Tasks;
using NNChallenge.Interfaces;

namespace NNChallenge.WeatherForcast
{
    public class WeatherForcastModel
    {
        private readonly IWeatherForcastRepository _weatherForcastRepository;

        public WeatherForcastModel(IWeatherForcastRepository weatherForcastRepository)
        {
            _weatherForcastRepository = weatherForcastRepository ?? throw new ArgumentNullException(nameof(weatherForcastRepository));
        }

        public async Task<Result<IWeatherForcastVO>> CreateForcastForCityAsync(string city)
        {
            try
            {
                var result = await _weatherForcastRepository.GetAsync(new WeatherForcastRequest(city));

                return Result<IWeatherForcastVO>.SuccessResult(result);
            }
            catch (Exception ex)
            {
                return Result<IWeatherForcastVO>.ErrorResult("Something went wrong. Please try again later or contact support.");
            }
        }
    }
}