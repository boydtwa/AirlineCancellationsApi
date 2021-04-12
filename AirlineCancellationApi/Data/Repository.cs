using AirlineCancellationApi.Extensions;
using AirlineCancellationApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineCancellationApi.Data
{
    public class Repository
    {
        private List<AirportMonthModel> AirportMonths { get; set; }
        public Repository()
        {
            var r = new StreamReader("Data/airlines.json");
            var json = r.ReadToEnd();
            AirportMonths =  JsonConvert.DeserializeObject<List<AirportMonthModel>>(json);
        }
        public IEnumerable<AirportMonthModel> GetAll()
        {
            return AirportMonths.AsEnumerable();
        }
        /// <summary>
        ///  Was experiencing timeout issues in theory the query could be one statement
        /// don't have time to debug this any further
        /// </summary>
        public IEnumerable<AirportMonthModel> FilterQuery(IRequestBody Parameters)
        {
            if (Parameters.Query == null)
                return GetAll().If(Parameters.Skip >0, td =>td.Skip(Parameters.Skip))
                    .If(Parameters.Take>0, td=>td.Take(Parameters.Take));

            var query = AirportMonths.Where(td=>td.Airport != null);
            var query2 = query.If(!string.IsNullOrEmpty(Parameters.Query.AirportCode),
                q => q.Where(td => td.Airport.Code == Parameters.Query?.AirportCode));

            query = query2.Any() ? query2.ToList<AirportMonthModel>().AsEnumerable() : query;


            query2 =  query.If( Parameters.Query.FlightCount != null && Parameters.Query.FlightCount.Minimum > 0, q => q.Where(
                            (td => (td.Statistics.Flights.Total) >= Parameters.Query.FlightCount?.Minimum)))
                        .If(Parameters.Query.FlightCount?.Maximum > 0, q => q.Where(
                        (td => td.Statistics.Flights.Total <= Parameters.Query.FlightCount.Maximum)));

            query = query2.Any() ? query2.ToList<AirportMonthModel>().AsEnumerable() : query;

            query2 = query.If(
            Parameters.Query.DelayCount?.Minimum > 0, q => q.Where(
                (td => td.Statistics != null)).Where(
                (td => (td.Statistics?.OfDelays?.Carrier +
                        td.Statistics?.OfDelays?.LateAircraft +
                        td.Statistics?.OfDelays?.NationalAviationSystem +
                        td.Statistics?.OfDelays?.Security +
                        td.Statistics?.OfDelays?.Weather) >= Parameters.Query?.DelayCount.Minimum)));

            query = query2.Any() ? query2.ToList<AirportMonthModel>().AsEnumerable() : query;

            query2 = query.If(
                Parameters.Query.DelayCount?.Maximum > 0 &&
                Parameters.Query.DelayCount?.Maximum >= Parameters.Query.DelayCount?.Minimum, q => q.Where(
                    (td => (td.Statistics.OfDelays.Carrier +
                    td.Statistics.OfDelays.LateAircraft + td.Statistics.OfDelays.NationalAviationSystem +
                    td.Statistics.OfDelays.Security + td.Statistics.OfDelays.Weather) <= Parameters.Query.DelayCount.Maximum)));

            query = query2.Any() ? query2.ToList<AirportMonthModel>().AsEnumerable() : query;


            query2 = query.If(!string.IsNullOrEmpty(Parameters.Query?.Since),
                    q => q.Where(td => td.Time.GetDate() >= td.Time.GetDate(Parameters.Query.Since)));

            query = query2.Any() ? query2.ToList<AirportMonthModel>().AsEnumerable() : query;

            query2 = query.If(!string.IsNullOrEmpty(Parameters.Query?.Until),
                    q => q.Where(td => td.Time.GetDate() <= td.Time.GetDate(Parameters.Query.Until)));

            query = query2.Any() ? query2.ToList<AirportMonthModel>().AsEnumerable() : query;

           query = query.If(Parameters?.Skip>0, q=>q.Skip(Parameters.Skip));
           query = query.If(Parameters?.Take>0, q => q.Take(Parameters.Take));

            return query;
        }
    }
}
