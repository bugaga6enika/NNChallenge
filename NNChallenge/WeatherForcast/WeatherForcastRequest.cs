using System;
using NNChallenge.Interfaces;

namespace NNChallenge.WeatherForcast
{
    public class WeatherForcastRequest : IWeatherForcastRequest
    {
        public string City { get; }

        public int ForecastWindow { get; }


        private WeatherForcastRequest()
        {
        }

        public WeatherForcastRequest(string city, int forecastWindow = 3)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace.", nameof(city));
            }

            if (forecastWindow < 1 || forecastWindow > 14)
            {
                throw new InvalidForcastWindowException(1, 14);
            }

            City = city;
            ForecastWindow = forecastWindow;
        }
    }
}

