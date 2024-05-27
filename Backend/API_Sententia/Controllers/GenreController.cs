
using Business;
using Microsoft.AspNetCore.Mvc;
using Models.Genre;

namespace API_Sententia.Controllers
{
    [Route("[controller]")]
    public class GenreController : Controller
    {
        private readonly GenreService _genreService;

        public GenreController(IConfiguration config)
        {
            _genreService = new GenreService(config);
        }

        [HttpPost]
        public async Task<ActionResult<GenrePost_Response>> PostAsync([FromBody] GenrePost_Request genre)
        {
            try
            {
                var genreCreated = await _genreService.PostAsync(genre);

                if (genreCreated == null)
                {
                    return NotFound();
                }
                return Ok(genreCreated);
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
