using FundaFifo.TTFunction.Common.Helpers;
using FundaFifo.TTFunction.Common.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FundaFifo.TTFunction.Startup))]

namespace FundaFifo.TTFunction
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			builder.Services.AddSingleton<IFundaParser, FundaParser>();
		}
	}
}