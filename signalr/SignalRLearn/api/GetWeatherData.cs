using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace api
{
    public static class GetWeatherData
    {
        [FunctionName("GetWeather")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "GetWeather/{city}")] HttpRequest req,
            [CosmosDB(
                databaseName: "WeatherData",
                collectionName: "ForecastValue",
                ConnectionStringSetting = "CosmosConnection",
                Id = "{city}",
                PartitionKey = "{city}")]WeatherForecastData data,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var myObj = new { name = new { city=data.City, country=data.Country }, weather = new { temp=data.Temperature, icon=data.Icon, description=data.Description } };
            var jsonToReturn = JsonConvert.SerializeObject(myObj);

            return new OkObjectResult(jsonToReturn);
        }
    }

    public class WeatherForecastData
    {
        public string City { get; set; }
        public string Country { get; set; }
        public long Temperature { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

}
