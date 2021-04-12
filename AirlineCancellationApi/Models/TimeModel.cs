using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirlineCancellationApi.Models
{
    //see: https://json2csharp.com/json-to-csharp
    public class TimeModel
    {
        [JsonProperty("Label")]
        public string Label => $"{this.Month}/{this.Year}";

        [JsonProperty("Month")]
        public int Month { get; set; }

        [JsonProperty("Month Name")]
        public string MonthName { get; set; }

        [JsonProperty("Year")]
        public int Year { get; set; }

        public DateTime GetDate() => new DateTime(Year, Month,1,0,0,0);

        public DateTime GetDate(string DateString)
        {
            var dateVals = DateString.Split("/");
            if (dateVals.Length != 2)
                throw new ArgumentException("DateString is malformed expect Month/Year format");

            int year;
            int month; 
            if(int.TryParse(dateVals[1],out year) && int.TryParse(dateVals[0], out month) && year > 1900 && month > 0 && month < 13)
                return new DateTime(year, month,1,0,0,0);

            return new DateTime();
        }

    }
}
