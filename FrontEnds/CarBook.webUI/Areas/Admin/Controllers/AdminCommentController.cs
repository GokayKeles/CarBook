using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{blogId}")]
        public async Task<IActionResult> Index(int blogId)
        {
            ViewBag.v = blogId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7026/api/Comments/CommentListByBlog/{blogId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("RemoveComment/{id}")]
public async Task<IActionResult> RemoveComment(int id)
{
    var client = _httpClientFactory.CreateClient();
    
    // Yorum Silme
    
    var getResponse = await client.GetAsync($"https://localhost:7026/api/Comments/{id}");
    if (getResponse.IsSuccessStatusCode)
    {
        // Yorumları alma isteği
        
        var deleteResponse = await client.DeleteAsync($"https://localhost:7026/api/Comments/{id}");
        if (deleteResponse.IsSuccessStatusCode)
        {
            var commentsJson = await getResponse.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<ResultCommentDto>(commentsJson);
            
            // Yorumları ViewBag'e atıyoruz
            ViewBag.blogId = comments.BlogID;
            
            return RedirectToAction("Index", "AdminComment", new { area = "Admin", ViewBag.blogId });
        }
    }
    
    return View();
}

    }
}
