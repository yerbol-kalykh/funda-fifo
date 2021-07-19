using FundaFifo.TTFunction.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundaFifo.TTFunction.Common.Interfaces
{
	public interface IFundaParser
    {
        Task<IEnumerable<PropertyDto>> GetPropertiesAsync(string filter);
    }
}