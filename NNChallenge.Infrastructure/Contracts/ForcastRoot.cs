using Newtonsoft.Json;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class ForcastRoot
    {
        [JsonConstructor]
        public ForcastRoot(
            [JsonProperty("location")] Location location,
            [JsonProperty("forecast")] Forcast forecast
        )
        {
            this.Location = location;
            this.Forecast = forecast;
        }

        [JsonProperty("location")]
        public Location Location { get; }

        [JsonProperty("forecast")]
        public Forcast Forecast { get; }
    }
}
