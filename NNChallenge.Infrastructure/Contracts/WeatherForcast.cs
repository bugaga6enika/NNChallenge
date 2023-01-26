using System;
using System.Linq;
using NNChallenge.Interfaces;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class WeatherForcast : IWeatherForcastVO
    {
        public string City { get; }

        public IHourWeatherForecastVO[] HourForecast { get; }

        public WeatherForcast(ForcastRoot forcastRoot)
        {
            _ = forcastRoot ?? throw new ArgumentNullException(nameof(forcastRoot));

            City = forcastRoot.Location.Name;
            HourForecast = forcastRoot.Forecast.ForecastDay.SelectMany(x => x.Hour.Select(s => new HourWeatherForecast(s))).ToArray();
        }
    }
}
