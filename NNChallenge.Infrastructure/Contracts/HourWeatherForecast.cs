using System;
using NNChallenge.Interfaces;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class HourWeatherForecast : IHourWeatherForecastVO
    {
        public DateTime Date { get; }

        public float TeperatureCelcius { get; }

        public float TeperatureFahrenheit { get; }

        public string ForecastPitureURL { get; }

        public HourWeatherForecast(Hour hour)
        {
            _ = hour ?? throw new ArgumentNullException(nameof(hour));

            if (DateTime.TryParse(hour.Time, out var dateTimeParsed))
            {
                Date = dateTimeParsed;
            }
            else
            {
                throw new ArgumentException(nameof(hour.Time));
            }

            TeperatureCelcius = (float)hour.TempC;
            TeperatureFahrenheit = (float)hour.TempF;
            ForecastPitureURL = !hour.Condition.Icon.StartsWith("http") ? hour.Condition.Icon.Insert(0, "https:") : hour.Condition.Icon;
        }
    }
}
