using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    //see: https://json2csharp.com/json-to-csharp
    public class AirportModel
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
