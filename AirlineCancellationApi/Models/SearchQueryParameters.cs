using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AirlineCancellationApi.Models
{
    public class SearchQueryParameters
    {
        [JsonProperty("airportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("delayCount")]
        public DelayCountModel DelayCount { get; set; }

        [JsonProperty("flightCount")]
        public FlightCountModel FlightCount { get; set; }

        [JsonProperty("since")]
        public string Since { get; set; }

        [JsonProperty("until")]
        public string Until { get; set; }
    }
}
