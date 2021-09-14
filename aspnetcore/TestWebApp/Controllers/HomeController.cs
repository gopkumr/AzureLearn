using Azure.Core;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenAcquisition tokenAcquisition;

        public HomeController(ILogger<HomeController> logger)
        {
            System.Diagnostics.Trace.TraceInformation("This is a log entry");
            _logger = logger;
            //this.tokenAcquisition = tokenAcquisition;
        }

        public async Task<IActionResult> Index()
        {
            //var token = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { "User.Read" });
            ViewBag.Name = User.Identity.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Upload()
        {
            return View(new UploadModel() { ResponseMessage = "" });
        }

        [HttpPost]
        [ActionName("Upload")]
        public async Task<IActionResult> UploadData()
        {
            try
            {
                IConfidentialClientApplication app;
                app = ConfidentialClientApplicationBuilder.Create("b64b92c3-1bfc-49d3-b54b-578e066d8b7e")
                                                          .WithClientSecret("--")
                                                          .WithAuthority(new Uri("https://login.microsoftonline.com/e202612e-d871-4516-a5e5-3a79e2a8f1ef"))
                                                          .Build();
                string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
                var result = await app.AcquireTokenForClient(scopes)
                                      .ExecuteAsync();

                var storageUri = new Uri("https://adstorage001.blob.core.windows.net/");

                var fileName = Request.Form.Files.First().FileName.Split("/", StringSplitOptions.RemoveEmptyEntries).Last();

                

                var blobServiceClient = new BlobServiceClient(storageUri,credential: new MyTokenCredential(result));
                var containerClient = blobServiceClient.GetBlobContainerClient("aduploda");
                containerClient.UploadBlob(fileName, Request.Form.Files.First().OpenReadStream());

                return View(new UploadModel { ResponseMessage = "Uploaded" });
            }
            catch (Exception ex)
            {
                return View(new UploadModel { ResponseMessage = ex.Message });
            }
        }

        public IActionResult CosmosDB()
        {
            return View(new CustomerOrder());
        }

        [HttpPost]
        public async Task<IActionResult> CosmosDB(CustomerOrder model)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=cosmosacc001;AccountKey=;TableEndpoint=https://cosmosacc001.table.cosmos.azure.com:443/;";
            string dbName = "CustomerDB";
            string customerContainerName = "customer";
            string orderContainerName = "order";

            var cloudAccount= CloudStorageAccount.Parse(connectionString);
            var tableClient = cloudAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(customerContainerName);

            model.Customer.PartitionKey = model.Customer.City;
            model.Customer.RowKey = Guid.NewGuid().ToString();
            var tableOperation = TableOperation.Insert(model.Customer);
            var result=table.Execute(tableOperation);

            //using (var client = new Microsoft.Azure.Cosmos.CosmosClient(connectionString))
            //{
            //    var db = client.GetDatabase(dbName);
            //    var customerContainer = db.GetContainer(customerContainerName);
            //    if (model.Customer.id == Guid.Empty)
            //    {
            //        model.Customer.id = Guid.NewGuid();
            //        var customerResponse = await customerContainer.CreateItemAsync<Customer>(model.Customer);
            //    }
            //    else
            //    {
            //        model.Customer = await customerContainer.ReadItemAsync<Customer>(model.Customer.id.ToString(), new Microsoft.Azure.Cosmos.PartitionKey(model.Customer.City));
            //    }

            //    //var orderContainer = db.GetContainer(orderContainerName);
            //    //if (model.Order.id == Guid.Empty)
            //    //    model.Order.id = Guid.NewGuid();
            //    //model.Order.CustomerId = model.Customer.id;
            //    //var orderResponse = await orderContainer.CreateItemAsync<Order>(model.Order);
            //}

            model.ResponseMessage = "Items inserted for " + result.ActivityId;
            return View(model);
        }
    }
}
