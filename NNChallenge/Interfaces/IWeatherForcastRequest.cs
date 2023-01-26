using System;
namespace NNChallenge.Interfaces
{
    public interface IWeatherForcastRequest
    {
        public string City { get; }

        public int ForecastWindow { get; }
    }
}
