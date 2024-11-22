﻿using TrendShop.DtoLayer.DiscountDtos;

namespace TrendShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            //var responseMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCode/{code}");
            var responseMessage = await _httpClient.GetAsync("http://localhost:7208/api/Discounts/GetCodeDetailByCode?code=" + code);

            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7208/api/Discounts/GetDiscountCouponCountRate?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }


    }
}

// var responseMessage = await _httpClient.GetAsync("http://localhost:7208/api/Discounts/GetDiscountCouponCountRate?code=" + code)
