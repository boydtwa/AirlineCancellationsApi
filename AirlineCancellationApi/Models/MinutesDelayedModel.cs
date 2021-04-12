using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    //see: https://json2csharp.com/json-to-csharp
    public class MinutesDelayedModel
    {
        [JsonProperty("Carrier")]
        public int Carrier { get; set; }

        [JsonProperty("LateAircraft")]
        public int LateAircraft { get; set; }

        [JsonProperty("NationalAviationSystem")]
        public int NationalAviationSystem { get; set; }

        [JsonProperty("Security")]
        public int Security { get; set; }

        [JsonProperty("Total")]
        public int Total { get; set; }

        [JsonProperty("Weather")]
        public int Weather { get; set; }
    }
}
