using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace testFunction
{
    public static class HttpTriggerCSharp
    {
        [FunctionName("HttpTriggerCSharp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string operacao = req.Query["Operacao"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            
            CalcService calc = new CalcService();
            int result = calc.Operations(data,log,operacao);
            String response = String.Format("Hello, {0} resultado da Operação {1}",operacao,result.ToString());

            
            log.LogInformation("Return of SumService");
            return !String.IsNullOrEmpty(response) | !String.IsNullOrWhiteSpace(response)
                ? (ActionResult)new OkObjectResult(response)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
