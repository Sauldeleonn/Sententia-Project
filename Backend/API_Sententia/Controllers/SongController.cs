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
        public async Task<ActionResult<SongPost_Response>> CreateSong([FromBody]SongPost_Request post_Request)
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

        [HttpGet]
        public async Task<ActionResult<SongGetAll_Response>> GetSongs()
        {
            try
            {
                var response = await _SongService.GetSongs();

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

        [HttpGet]
        [Route("Popular")]
        public async Task<ActionResult<SongGetAll_Response>> GetPopularSongs()
        {
            try
            {
                var response = await _SongService.GetSongs();

                //limit the response to 10 random songs
                response.Songs = response.Songs.OrderBy(x => Guid.NewGuid()).Take(10).ToList(); //randomize the list

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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SongGetById_Response>> GetSongById(int id)
        {
            try
            {
                var response = await _SongService.GetSongById(id);

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

        [HttpPut]
        public async Task<ActionResult<SongPut_Response>> UpdateSong([FromBody]SongPut_Request put_Request)
        {
            try
            {
                var response = await _SongService.UpdateSong(put_Request);

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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SongDelete_Response>> DeleteSong(int id)
        {
            try
            {
                var response = await _SongService.DeleteSong(id);

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
