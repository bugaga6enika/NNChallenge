using System.Collections.Generic;
using Newtonsoft.Json;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class Forcast
    {
        [JsonConstructor]
        public Forcast(
            [JsonProperty("forecastday")] List<ForcastDay> forecastDay
        )
        {
            this.ForecastDay = forecastDay;
        }

        [JsonProperty("forecastday")]
        public IReadOnlyList<ForcastDay> ForecastDay { get; }
    }
}