using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.webUI.Controllers
{
    public class RentACarListController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index(int id)
        {
            var bookpickdate = TempData["bookpickdate"];
            var bookoffdate = TempData["bookoffdate"];
            var timepick = TempData["timepick"];
            var timeoff = TempData["timeoff"];
            var LocationID = TempData["LocationID"];

			//filterRentACarDto.LocationID = int.Parse(LocationID.ToString());
			//filterRentACarDto.Available = true;
			id = int.Parse(LocationID.ToString());

			ViewBag.LocationID = LocationID;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7026/api/RentACar?LocationID={id}&available=true");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
				return View(values);
			}
			return View();
		}
    }
}
