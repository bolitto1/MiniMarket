using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MiniMarket.Entidades.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace MiniMarket.MVC.Controllers
{
	public class ProductosController : Controller
	{
		string BaseUrl = "";
		private readonly IConfiguration _configuracion;
		public ProductosController(IConfiguration configuracion)
		{
			_configuracion = configuracion;
			BaseUrl = _configuracion.GetValue<string>("webAPI");
		}
		public async Task< IActionResult> Index()
		{
			List<Productos> productosList = new List<Productos>();
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(BaseUrl);
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			//nombre del controlador que estamos invocando con http get
			HttpResponseMessage Res= await client.GetAsync("Productos");
			if (Res.IsSuccessStatusCode)
			{
				var _ClienteResponse = Res.Content.ReadAsStringAsync().Result;
				productosList = JsonConvert.DeserializeObject<List<Productos>>(_ClienteResponse);
			}
			return View(productosList);
		}
	}
}
