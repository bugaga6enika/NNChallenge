using Newtonsoft.Json;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class Hour
    {
        [JsonConstructor]
        public Hour(
            [JsonProperty("time")] string time,
            [JsonProperty("temp_c")] double? tempC,
            [JsonProperty("temp_f")] double? tempF,
            [JsonProperty("condition")] Condition condition
        )
        {
            this.Time = time;
            this.TempC = tempC;
            this.TempF = tempF;
            this.Condition = condition;
        }

        [JsonProperty("time")]
        public string Time { get; }

        [JsonProperty("temp_c")]
        public double? TempC { get; }

        [JsonProperty("temp_f")]
        public double? TempF { get; }

        [JsonProperty("condition")]
        public Condition Condition { get; }
    }
}
