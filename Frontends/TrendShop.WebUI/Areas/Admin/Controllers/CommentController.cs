﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TrendShop.DtoLayer.CatalogDtos.ProductDtos;
using TrendShop.DtoLayer.CommentDtos;

namespace TrendShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v4 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();

            var responseComments = await client.GetAsync("https://localhost:7293/api/Comments");
            if (!responseComments.IsSuccessStatusCode)
            {
                return View();
            }

            var jsonComments = await responseComments.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonComments);

            var responseProducts = await client.GetAsync("https://localhost:7207/api/Products");
            if (!responseProducts.IsSuccessStatusCode)
            {
                return View();
            }

            var jsonProducts = await responseProducts.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonProducts);

            foreach (var comment in comments)
            {
                var product = products.FirstOrDefault(p => p.ProductID == comment.ProductID);
                if (product != null)
                {
                    comment.ProductName = product.ProductName; 
                }
            }

            return View(comments);
        }


        [Route("DeleteComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7293/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Güncelleme Sayfası";
            ViewBag.v4 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7293/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7293/api/Comments/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
