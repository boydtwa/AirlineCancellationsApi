using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineCancellationApi.Models
{
    interface IAirportMonth
    {
        AirportModel Airport { get; set; }
        TimeModel Time { get; set; }

        StatisticsModel Statistics { get; set; }
    }
}
