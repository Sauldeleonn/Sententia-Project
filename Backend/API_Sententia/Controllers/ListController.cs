using DataAccess.Repository;
using DataAccess.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Models.List;
using Models.MusicalElement;

namespace API_Sententia.Controllers
{
    [Route("[Controller]")]
    public class ListController : Controller
    {
        private readonly MusicalReviewsDbContext _context;
        public ListController(IConfiguration config)
        {
            _context = new MusicalReviewsDbContext(config);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ListPost_Request request)
        {
            var list = new List
            {
                Name = request.Name
            };

            _context.Lists.Add(list);
            _context.SaveChanges();

            return Ok(new ListPost_Response { ListId = list.ListId });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lists = _context.Lists.ToList();
            var response = new ListGetAll_Response
            {
                Lists = lists.Select(l => new ListModel
                {
                    ListId = l.ListId,
                    Name = l.Name
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var list = _context.Lists.Find(id);
            if (list == null)
            {
                return NotFound();
            }

            var response = new ListGetById_Response
            {
                ListId = list.ListId,
                Name = list.Name,
                MusicalElements = list.MusicalElements.Select(me => new MusicalElementModel
                {
                    MusicalElementId = me.MusicalElementId,
                    Name = me.Name,
                    Bio = me.Bio,
                    MusicalElementTypeId = me.MusicalElementTypeId,
                    ReleaseDate = me.MusicalElement3.ReleaseDate ?? null 
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ListPut_Request request)
        {
            var list = _context.Lists.Find(request.ListId);
            if (list == null)
            {
                return NotFound();
            }

            list.Name = request.Name;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ListDelete_Request request)
        {
            var list = _context.Lists.Find(request.ListId);
            if (list == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(list);
            _context.SaveChanges();

            return Ok(new ListDelete_Response { ListId = list.ListId });
        }

        //add MusicalElement to List
        [HttpPost("AddElement")]
        public  IActionResult AddSong([FromBody] ListAddMusicalElement_Request request)
        {
            var list = _context.Lists.Find(request.ListId);
            if (list == null)
            {
                return NotFound();
            }

            var element = _context.MusicalElements.Find(request.MusicalElementId);
            if (element == null)
            {
                return NotFound();
            }

            _context.Lists.Find(request.ListId).MusicalElements.Add(element);
            _context.SaveChanges();

            return Ok(new ListAddMusicalElement_Response { ListId = list.ListId, MusicalElementId = element.MusicalElementId });
        }

        //remove MusicalElement from List
        [HttpDelete("RemoveSong")]
        public IActionResult RemoveSong([FromBody] ListRemoveMusicalElement_Request request)
        {
            var list = _context.Lists.Find(request.ListId);
            if (list == null)
            {
                return NotFound();
            }

            var element = _context.MusicalElements.Find(request.MusicalElementId);
            if (element == null)
            {
                return NotFound();
            }

            _context.Lists.Find(request.ListId).MusicalElements.Remove(element);
            _context.SaveChanges();

            return Ok(new ListRemoveMusicalElement_Response { ListId = list.ListId, MusicalElementId = element.MusicalElementId });
        }
    }
}
