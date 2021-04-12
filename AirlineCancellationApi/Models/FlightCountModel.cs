using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    public class FlightCountModel
    {
        [JsonProperty("minimum")]
        public int? Minimum { get; set; }

        [JsonProperty("maximum")]
        public int? Maximum { get; set; }
    }
}
