using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    public class RequestBody : IRequestBody
    {
        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("take")]
        public int Take { get; set; }

        [JsonProperty("query")]
        public SearchQueryParameters Query { get; set; }
    }
}
