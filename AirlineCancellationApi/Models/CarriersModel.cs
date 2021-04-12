using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    //see: https://json2csharp.com/json-to-csharp
    public class CarriersModel
    {
        [JsonProperty("Names")]
        public string Names { get; set; }

        [JsonProperty("Total")]
        public int Total { get; set; }
    }
}
