using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    public class QueryModel
    {
        [JsonProperty("airportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("delayCount")]
        public DelayCountModel DelayCount { get; set; }

        [JsonProperty("flightCount")]
        public FlightCountModel FlightCount { get; set; }

    }
}
