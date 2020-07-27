using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NocaManegmentNew.Models;

namespace NocaManegmentNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private NOCAManagmentContext _nOCAManagmentContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, NOCAManagmentContext nOCAManagmentContext)
        {
            _logger = logger;
            _nOCAManagmentContext = nOCAManagmentContext;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{

        //    var t = _nOCAManagmentContext.Baskets.Select(x => x).ToList();

        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {

        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpGet]
        public IEnumerable<Cabinets> CabinetsGet() 
       {
            var t = _nOCAManagmentContext.Cabinets.Select(x => x).ToList();

            var db = _nOCAManagmentContext.Cabinets.Select(x => new Cabinets()
            {

                Id = x.Id,
                Num = x.Num,
                //Shelfes = _nOCAManagmentContext.Shelfes.Select(x => x).ToList()

            });

            return t;
        }
    }
}
