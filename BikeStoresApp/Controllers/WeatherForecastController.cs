using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BikeStoresApp.Controllers
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

        private readonly IHttpClientFactory _clientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [Route("default")]
        [HttpGet]
        public async Task<IActionResult> OnGet()
        {
            var uri = new Uri("https://localhost:44382/api/brand");

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content.ReadAsStreamAsync().Result);
            }
            else
            {
                return StatusCode(500, "Somwthing went wrong, error occured");
            }

        }


        [Route("named")]
        [HttpGet]
        public async Task<IActionResult> OnGetNamed()
        {
            var uri = new Uri("https://localhost:44382/api/brand");

            var client = _clientFactory.CreateClient("BrandClient");

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content.ReadAsStreamAsync().Result);
            }
            else
            {
                return StatusCode(500, "Somwthing went wrong, aerror occured");
            }

        }



    }
}
