using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using PercentageCalculator.Logic;

namespace PercentageCalculator
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
                                                    HttpRequest req,
                                                    [Table("Logs")] CloudTable percentageCalculationInputTable,
                                                    TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var requestRoot = JsonConvert.DeserializeObject<Models.Request.Root>(requestBody);

            var response = new RequestHandler().Execute(requestRoot);

            await LogRequestAsync(percentageCalculationInputTable, requestBody, response);

            return new OkObjectResult(response);
        }

        private static async Task LogRequestAsync(CloudTable cloudTable, string requestBody, Models.Response.Root response)
        {
            var entity = new PercentageCalculatorEntity
                         {
                                 PartitionKey = Guid.NewGuid().ToString(),
                                 RowKey = Guid.NewGuid().ToString(),
                                 Request = requestBody,
                                 Response = JsonConvert.SerializeObject(response)
                         };
            var updateOperation = TableOperation.InsertOrReplace(entity);
            await cloudTable.ExecuteAsync(updateOperation);
        }
    }
}