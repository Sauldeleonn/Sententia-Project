using Business;
using Microsoft.AspNetCore.Mvc;

namespace API_Sententia.Controllers
{
    [Route("[Controller]")]
    public class ReportsController : Controller
    {
        private readonly ReportsService _service;
        public ReportsController(IConfiguration config)
        {
            _service = new ReportsService(config);
        }

        [HttpGet]
        [Route("SongReport")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var fileContent = await _service.GetSongsReportAsync();
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SongsReport.xlsx");
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
