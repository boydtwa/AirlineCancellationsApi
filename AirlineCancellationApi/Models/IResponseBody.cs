using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AirlineCancellationApi.Models
{
    public interface IResponseBody
    {
        IEnumerable<AirportMonthModel> Results { get; set; }
        int TotalCount { get; set; }
    }
}
