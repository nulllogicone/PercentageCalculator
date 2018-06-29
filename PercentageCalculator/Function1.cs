
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PercentageCalculator
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req,
            [Table("Logs")]CloudTable percentageCalculationInputTable,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var data = JsonConvert.DeserializeObject<Input>(requestBody);
            var sum = data.Values.Select(x => x.Value).Sum();
            var percentages = new List<int>();
            foreach (var value in data.Values)
            {
                var percentage = (int)System.Math.Round((decimal)value.Value / sum * 100);
                percentages.Add(percentage);
            }

            var entity = new PercentageCalculatorEntity()
            {
                PartitionKey = System.Guid.NewGuid().ToString(),
                RowKey = System.Guid.NewGuid().ToString(),
                Request = requestBody,
                Response = JsonConvert.SerializeObject(percentages)
            };
            var updateOperation = TableOperation.InsertOrReplace(entity);
            await percentageCalculationInputTable.ExecuteAsync(updateOperation);

            return (ActionResult)new OkObjectResult(percentages);
            //return result != null
            //    ? (ActionResult)new OkObjectResult(result)
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
