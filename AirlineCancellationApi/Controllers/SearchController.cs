using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineCancellationApi.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using AirlineCancellationApi.Extensions;
using AirlineCancellationApi.Data;

namespace AirlineCancellationApi.Controllers
{
    [Route("api/airport-cancellations/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {


        [HttpPost]
        public IResponseBody Post(RequestBody Request)
        {
            var repo = new Repository();

            var filterAirports = repo.FilterQuery(Request);

            return new ResponseBody() { Results = filterAirports, TotalCount = filterAirports.Count() };

        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Anything but a 404 Error")
            };
        }
    }
}
