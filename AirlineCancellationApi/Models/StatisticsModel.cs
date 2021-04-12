using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    //see: https://json2csharp.com/json-to-csharp
    public class StatisticsModel
    {
        [JsonProperty("# of Delays")]
        public OfDelaysModel OfDelays { get; set; }

        [JsonProperty("Carriers")]
        public CarriersModel Carriers { get; set; }

        [JsonProperty("Flights")]
        public FlightsModel Flights { get; set; }

        [JsonProperty("MinutesDelayed")]
        public MinutesDelayedModel MinutesDelayed { get; set; }
    }
}
