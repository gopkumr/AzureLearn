using System;
using System.Data.SqlClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace SqlFunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("incomingqueue", Connection = "AzureWebJobsStorage")]JObject myQueueItem, ILogger log)
        {
            var connectionString = Environment.GetEnvironmentVariable("sqlConnectionString");
            var sqlCon = new SqlConnection(connectionString);

            var id = myQueueItem.Value<string>("id");
            var name = myQueueItem.Value<string>("name");
            var commandtext = $"insert into mycustomer(id, name) values('{id}', '{name}')";

            var cmd = new SqlCommand(commandtext, sqlCon);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
