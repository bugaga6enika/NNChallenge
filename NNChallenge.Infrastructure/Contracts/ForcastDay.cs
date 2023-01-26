using System.Collections.Generic;
using Newtonsoft.Json;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class ForcastDay
    {
        [JsonConstructor]
        public ForcastDay(
            [JsonProperty("hour")] List<Hour> hour
        )
        {
            this.Hour = hour;
        }

        [JsonProperty("hour")]
        public IReadOnlyList<Hour> Hour { get; }
    }
}
