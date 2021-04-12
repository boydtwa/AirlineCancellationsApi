using System;
using System.Collections.Generic;
using System.Linq;


namespace AirlineCancellationApi.Models
{
    public interface IRequestBody
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public SearchQueryParameters Query { get; set; }
    }
}
