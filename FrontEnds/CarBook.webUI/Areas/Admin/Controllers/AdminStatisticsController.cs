﻿using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]

        public async Task<IActionResult> Index()
        {
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.CarCount;
            }
            #endregion

            #region LocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7026/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.v2 = values2.LocationCount;
            }
            #endregion

            #region AuthorCount
            var responseMessage3 = await client.GetAsync("https://localhost:7026/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.v3 = values3.AuthorCount;
            }
            #endregion

            #region BlogCount
            var responseMessage4 = await client.GetAsync("https://localhost:7026/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.v4 = values4.BlogCount;
            }
            #endregion

            #region BrandCount
            var responseMessage5 = await client.GetAsync("https://localhost:7026/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.v5 = values5.BrandCount;
            }
            #endregion

            #region TestimonialCount
            var responseMessage17 = await client.GetAsync("https://localhost:7026/api/Statistics/GetTestimonialCount");
            if (responseMessage17.IsSuccessStatusCode)
            {
                var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();
                var values17 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData17);
                ViewBag.v17 = values17.TestimonialCount;
            }
            #endregion

            #region AvgRentPriceForDailyCount
            var responseMessage6 = await client.GetAsync("https://localhost:7026/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.v6 = values6.AvgRentPriceForDaily.ToString("0.00");
            }
            #endregion

            #region AvgRentPriceForWeeklyCount
            var responseMessage7 = await client.GetAsync("https://localhost:7026/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.v7 = values7.AvgRentPriceForWeekly.ToString("0.00");
            }
            #endregion

            #region AvgRentPriceForMonthlyCount
            var responseMessage8 = await client.GetAsync("https://localhost:7026/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.v8 = values8.AvgRentPriceForMonthly.ToString("0.00");
            }
            #endregion

            #region CarCountByTransmissionIsAuto
            var responseMessage9 = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.v9 = values9.CarCountByTransmissionIsAuto;
            }
            #endregion

            #region BrandNameByMaxCar
               var responseMessage10 = await client.GetAsync("https://localhost:7026/api/Statistics/GetBrandNameByMaxCar");
               if (responseMessage10.IsSuccessStatusCode)
               {
                   var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                   var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                   ViewBag.v10 = values10.BrandNameByMaxCar;
               }
               #endregion

            #region BlogTitleByMaxBlogComment
               var responseMessage11 = await client.GetAsync("https://localhost:7026/api/Statistics/GetBlogTitleByMaxBlogComment");
               if (responseMessage11.IsSuccessStatusCode)
               {
                   var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                   var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                   ViewBag.v11 = values11.BlogTitleByMaxBlogComment;
               }
               #endregion

            #region CarCountByKmLessThen10000
            var responseMessage12 = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarCountByKmLessThen10000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.v12 = values12.CarCountByKmLessThen10000;
            }
            #endregion

            #region CarCountByFuelGasolineOrDiesel
            var responseMessage13 = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.v13 = values13.CarCountByFuelGasolineOrDiesel;
            }
            #endregion

            #region CarCountByFuelElectric
            var responseMessage14 = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.v14 = values14.CarCountByFuelElectric;
            }
            #endregion

            #region CarBrandAndModelByRentPriceDailyMax
            var responseMessage15 = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.v15 = values15.CarBrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region CarBrandAndModelByRentPriceDailyMin
            var responseMessage16 = await client.GetAsync("https://localhost:7026/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.v16 = values16.CarBrandAndModelByRentPriceDailyMin;
            }
            #endregion


            return View();
        }
    }
}
