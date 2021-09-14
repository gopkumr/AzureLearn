using ClientApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenAcquisition tokenAcquisition;
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor contextAccessor;
        private string apiURL= "https://localhost:44398/";

        public HomeController(ILogger<HomeController> logger, ITokenAcquisition tokenAcquisition, IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
            this.httpClient = httpClientFactory.CreateClient();
            this.configuration = configuration;
            this.contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetWeatherAsync()
        {
            var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { "api://APIappUri/Data.Read" });
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync($"{ apiURL}/weatherforecast");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.Content = await response.Content.ReadAsStringAsync();
            }
            else
            {
                ViewBag.Content = $"Invalid status code in the HttpResponseMessage: {response.StatusCode}.";
            }

            return View();
        }

        public async Task<IActionResult> WriteDataAsync()
        {
            var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { "api://APIappUri/Data.Write" });
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsoncontent = new StringContent("");
            var response = await httpClient.PostAsync($"{ apiURL}/weatherforecast", jsoncontent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.Content = await response.Content.ReadAsStringAsync();
            }
            else
            {
                ViewBag.Content = $"Invalid status code in the HttpResponseMessage: {response.StatusCode}.";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
