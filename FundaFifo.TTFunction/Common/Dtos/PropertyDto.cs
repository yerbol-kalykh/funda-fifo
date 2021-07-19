using System;

namespace FundaFifo.TTFunction.Common.Dtos
{
	public class PropertyDto
	{
		public string Title { get; set; }

		public string Postcode { get; set; }

		public Uri Url { get; set; }

		public string Price { get; set; }

		public static PropertyDto Create(string title, string postcode, string uri, string price)
		{
			return new PropertyDto
			{
				Title = title,
				Postcode = postcode,
				Url = new Uri(uri),
				Price = price
			};
		}
	}
}
