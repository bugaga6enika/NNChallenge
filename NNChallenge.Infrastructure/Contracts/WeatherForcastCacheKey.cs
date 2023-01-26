using System;
namespace NNChallenge.Infrastructure.Contracts
{
    internal class WeatherForcastCacheKey
    {
        private readonly string _city;
        private readonly string _date;

        public WeatherForcastCacheKey(string city, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace.", nameof(city));
            }

            _city = city;
            _date = date.Date.ToShortDateString();
        }

        public override string ToString()
        {
            return $"{_city}{_date}";
        }

        public static implicit operator string(WeatherForcastCacheKey weatherForcastCacheKey) => weatherForcastCacheKey.ToString();
    }
}

