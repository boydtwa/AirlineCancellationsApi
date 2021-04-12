using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    //see: https://json2csharp.com/json-to-csharp
    public class FlightsModel
    {
        [JsonProperty("Cancelled")]
        public int Cancelled { get; set; }

        [JsonProperty("Delayed")]
        public int Delayed { get; set; }

        [JsonProperty("Diverted")]
        public int Diverted { get; set; }

        [JsonProperty("OnTime")]
        public int OnTime { get; set; }

        [JsonProperty("Total")]
        public int Total { get; set; }
    }
}
