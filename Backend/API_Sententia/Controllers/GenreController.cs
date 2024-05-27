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

        //get
        [HttpGet]
        public async Task<ActionResult<List<GenreGet_Response>>> GetGenresAsync()
        {
            try
            {
                var genres = await _genreService.GetGenresAsync();

                if (genres == null)
                {
                    return NotFound();
                }
                return Ok(genres);
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

        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreGet_Response>> GetGenreByIdAsync(int id/*[FromQuery] GenreGetById_Request request*/)
        {
            try
            {
                var genre = await _genreService.GetGenreByIdAsync(id);

                if (genre == null)
                {
                    return NotFound();
                }
                return Ok(genre);
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

        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreDelete_Response>> DeleteGenreAsync(int id)
        {
            try
            {
                await _genreService.DeleteGenreAsync(id);
                return Ok(new GenreDelete_Response { GenreId = id });
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
