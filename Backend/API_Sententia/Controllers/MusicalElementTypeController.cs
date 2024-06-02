using Business;
using Microsoft.AspNetCore.Mvc;
using Models.MusicalElementType;

namespace API_Sententia.Controllers
{
    [Route("[Controller]")]
    public class MusicalElementTypeController : Controller
    {
        private readonly MusicalElementTypeService _service;
        public MusicalElementTypeController(IConfiguration configuration)
        {
            _service = new MusicalElementTypeService(configuration);
        }

        [HttpGet]
        public async Task<ActionResult<List<MusicalElementTypeGetAll_Response>>> GetAllAsync()
        {
            try
            {
                var response = await _service.GetAllAsync();

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
