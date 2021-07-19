using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FundaFifo.TTFunction
{
	public static class Program
    {
        [FunctionName("TimerTriggerFundaFifo")]
        public static void Run([TimerTrigger("0 */30 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
