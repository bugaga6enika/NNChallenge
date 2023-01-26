using Newtonsoft.Json;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class Condition
    {
        [JsonConstructor]
        public Condition(
            [JsonProperty("icon")] string icon
        )
        {
            this.Icon = icon;
        }

        [JsonProperty("icon")]
        public string Icon { get; }
    }
}
