using LearnWebAPI.Data;
using LearnWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public TypesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var typeList = _context.Types.ToList();
                return Ok(typeList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _context.Types.SingleOrDefault(ty => ty.TypeId == id);

            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [HttpPost]
        public IActionResult CreateNew(TypeModel model)
        {
            try
            {
                var type = new Data.Type
                {
                    TypeName = model.TypeName
                };

                _context.Add(type);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, type);
            }
            catch
            {
                return BadRequest();
            }      
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTypeById(int id, TypeModel model)
        {
            var type = _context.Types.SingleOrDefault(ty => ty.TypeId == id);

            if (type == null)
            {
                return NotFound();
            }

            type.TypeName = model.TypeName;

            _context.Update(type);
            _context.SaveChanges();

            return NoContent();
        }   

        [HttpDelete("{id}")]
        public IActionResult DeleteTypeById(int id)
        {
            var type = _context.Types.SingleOrDefault(ty => ty.TypeId == id);

            if (type == null)
            {
                return NotFound();
            }

            _context.Remove(type);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
