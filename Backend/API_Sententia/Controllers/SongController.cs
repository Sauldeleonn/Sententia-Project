using Business;
using Microsoft.AspNetCore.Mvc;
using Models.Song;

namespace API_Sententia.Controllers
{
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly SongService _SongService;

        public SongController(IConfiguration config)
        {
            _SongService = new SongService(config);
        }

        //post
        [HttpPost]
        public async Task<ActionResult<SongPost_Response>> CreateSong(SongPost_Request post_Request)
        {
            try
            {
                var response = await _SongService.CreateSong(post_Request);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(500, new { mensaje = e.Message });
#else
                return StatusCode(500, new { mensaje = "An error occurred while processing the request,report to the mail in the footer" });
#endif
            }
        }
    }
}
