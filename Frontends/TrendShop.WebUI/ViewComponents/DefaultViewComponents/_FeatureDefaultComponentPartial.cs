﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrendShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace TrendShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FeatureDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7207/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
