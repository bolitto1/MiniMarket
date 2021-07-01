using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace MiniMarket.MVC.Helper
{
	public class Helper1
	{
		public HttpClient Initial()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:44396/");
			return client;
		}
	}
}
