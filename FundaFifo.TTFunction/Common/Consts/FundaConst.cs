namespace FundaFifo.TTFunction.Common.Consts
{
	public class FundaConst
	{
		public const string BaseUrl = "https://www.funda.nl";

		public const string SearchResults = "//main//form//div[@class='container search-main']//div[@class='search-content']//div[@class='search-content-output']//ol[@class='search-results']";

		public const string SearchResultItem = "//li[@class='search-result']";

		public const string SearchResultContentNode = ".//div[@class='search-result-main']//div[@class='search-result-content']//div[@class='search-result-content-inner']";

		public const string SearchResultHeader = ".//div[contains(@class, 'search-result__header')]//div[contains(@class, 'search-result__header-title-col')]";

		public const string SearchResultUrl = ".//a[@href]";

		public const string SearchResultTitle = ".//h2[contains(@class, 'search-result__header-title')]";

		public const string SearchResultPostcode = ".//h4[contains(@class, 'search-result__header-subtitle')]";

		public const string SearchResultPrice = ".//span[@class='search-result-price']";
	}
}