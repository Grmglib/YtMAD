using Microsoft.AspNetCore.Mvc;

namespace YtMAD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YtmadController : ControllerBase
    {
       

        private readonly ILogger<YtmadController> _logger;

        public YtmadController(ILogger<YtmadController> logger)
        {
            _logger = logger;
        }

        [HttpGet("VideoInfo")]
        public async Task<IActionResult> GetVideoInfo(string url)
        {
            var video = await YoutubeRequests.VideoInfo(url);
            return Ok(video);
        }
        [HttpGet("VideoSearch")]
        public async Task<IActionResult> GetVideoSearch(string query)
        {
            var results = await YoutubeRequests.VideoSearch(query);
            return Ok(results);
        }
    }
}