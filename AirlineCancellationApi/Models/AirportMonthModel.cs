using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineCancellationApi.Models
{
    public class AirportMonthModel : IAirportMonth
    {
        public AirportModel Airport { get; set; }
        public TimeModel Time { get; set; }
        public StatisticsModel Statistics { get; set; }
    }
}
