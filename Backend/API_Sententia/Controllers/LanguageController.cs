using Business;
using Microsoft.AspNetCore.Mvc;
using Models.Language;

namespace API_Sententia.Controllers
{
    [Route("[Controller]")]
    public class LanguageController : Controller
    {
        private readonly LanguageService _languageService;

        public LanguageController(IConfiguration config)
        {
            _languageService = new LanguageService(config);
        }

        [HttpPost]
        public async Task<ActionResult<LanguagePost_Response>> PostLanguage([FromBody] LanguagePost_Request request)
        {
            try
            {
                var languageCreated = await _languageService.PostLanguage(request);

                if (languageCreated == null)
                {
                    return NotFound();
                }
                return Ok(languageCreated);
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
        public async Task<ActionResult<LanguageGetAll_Response>> GetAllLanguages()
        {
            try
            {
                var response = await _languageService.GetLanguages();

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

        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageGetById_Response>> GetLanguageById(int id)
        {
            try
            {
                var response = await _languageService.GetLanguageById(id);

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
        public async Task<ActionResult<LanguageModel>> UpdateLanguage([FromBody] LanguageModel language)
        {
            try
            {
                await _languageService.UpdateLanguage(language);

                var response = await _languageService.GetLanguageById(language.LanguageId);
                if (response == null)
                {
                    NotFound();
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<LanguageDelete_Response>> DeleteLanguage(int id)
        {
            try
            {
                var response = await _languageService.DeleteLanguage(id);

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
