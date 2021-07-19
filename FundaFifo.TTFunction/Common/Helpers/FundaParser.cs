using FundaFifo.TTFunction.Common.Consts;
using FundaFifo.TTFunction.Common.Dtos;
using FundaFifo.TTFunction.Common.Interfaces;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FundaFifo.TTFunction.Common.Helpers
{
	public class FundaParser : IFundaParser
	{
		public async Task<IEnumerable<PropertyDto>> GetPropertiesAsync(string filter)
		{
            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(await GetAsync($"{FundaConst.BaseUrl}/{filter}"));

            var searchResultsNode = htmlDoc.DocumentNode.SelectSingleNode(FundaConst.SearchResults);

            var childs = searchResultsNode.SelectNodes(FundaConst.SearchResultItem);

            var result = new List<PropertyDto>();

            foreach (var child in childs)
            {
                var searchResultContentNode = child.SelectSingleNode(FundaConst.SearchResultContentNode);

                var headerNode = searchResultContentNode.SelectSingleNode(FundaConst.SearchResultHeader);

                var urlNode = headerNode.SelectSingleNode(FundaConst.SearchResultUrl);

                var titleNode = headerNode.SelectSingleNode(FundaConst.SearchResultTitle);

                var postcode = headerNode.SelectSingleNode(FundaConst.SearchResultPostcode);

                var priceNode = searchResultContentNode.SelectSingleNode(FundaConst.SearchResultPrice);

                var propertyDto = PropertyDto.Create(titleNode.InnerText.Trim(), 
                    postcode.InnerText.Trim(), $"{FundaConst.BaseUrl}{urlNode.Attributes["href"].Value}", 
                    priceNode.InnerText.Trim().Split(' ')[1]);

                result.Add(propertyDto);
            }

            return result;
        }

        private async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using Stream stream = response.GetResponseStream();
            using StreamReader reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
}
