using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StrapiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public StrapiController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://backend-dev.studentschoice.blog")
            };
        }

        [HttpGet("blogs")]
        public async Task<IActionResult> GetBlogs()
        {
            var response = await _httpClient.GetAsync("/api/blogs");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}