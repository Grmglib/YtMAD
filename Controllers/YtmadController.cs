using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;
using YoutubeExplode.Playlists;
using YoutubeExplode.Videos.Streams;
using static System.Net.WebRequestMethods;

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
            var regex = new Regex(@"(?:https?:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|playlist\?|watch\?v=|watch\?.+(?:&|&#38;);v=))([a-zA-Z0-9\-_]{11})?(?:(?:\?|&|&#38;)index=((?:\d){1,3}))?(?:(?:\?|&|&#38;)?list=([a-zA-Z\-_0-9]{34}))?(?:\S+)?");
            var match = regex.Match(query);
            if(match.Success)
            {
                var video = await YoutubeRequests.VideoInfo(query);
                return Ok(video);
            }
            else
            {
                var results = await YoutubeRequests.VideoSearch(query);
                return Ok(results);
            }
            
        }
        [HttpGet("VideoDownload")]
        public async Task<IActionResult> GetVideoDownlaod(string url,string container,string path,double? resolution, string? bitrate)
        {
           var result = await YoutubeRequests.VideoDownload(url, container,path,resolution, bitrate);
            if(result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }  
        
        [HttpGet("StreamDownload")]
        public async Task<IActionResult> GetStreamDownlaod(string url,string container,double? resolution, string? bitrate)
        {
           var result = await YoutubeRequests.StreamDownload(url, container, resolution, bitrate);
           return Ok(result);
        }
    }
}