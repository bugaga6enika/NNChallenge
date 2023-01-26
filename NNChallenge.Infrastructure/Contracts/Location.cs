using Newtonsoft.Json;

namespace NNChallenge.Infrastructure.Contracts
{
    internal class Location
    {
        [JsonConstructor]
        public Location(
            string name,
            string region,
            string country,
            double? lat,
            double? lon,
            string tzId,
            int? localtimeEpoch,
            string localtime
        )
        {
            Name = name;
            Region = region;
            Country = country;
            Lat = lat;
            Lon = lon;
            TzId = tzId;
            LocaltimeEpoch = localtimeEpoch;
            Localtime = localtime;
        }

        public string Name { get; }
        public string Region { get; }
        public string Country { get; }
        public double? Lat { get; }
        public double? Lon { get; }
        public string TzId { get; }
        public int? LocaltimeEpoch { get; }
        public string Localtime { get; }
    }
}
