using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    public class ResponseBody : IResponseBody
    {
        [JsonProperty("results")]
        public IEnumerable<AirportMonthModel> Results { get; set; }
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
