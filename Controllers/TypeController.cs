using LearnWebAPI.Models;
using LearnWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;

        public TypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var typeList = _typeRepository.GetAll();
                return Ok(typeList);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var type = _typeRepository.GetById(id);

                if (type != null)
                {
                    return Ok(type);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(TypeModel model)
        {
            try
            {
                var type = _typeRepository.Add(model);
                return Ok(type);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTypeById(int id, TypeViewModel model)
        {
            if (id != model.TypeId)
            {
                return BadRequest();
            }

            try
            {   
                _typeRepository.Update(model);
                return NoContent();               
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTypeById(int id)
        {
            try
            {
                _typeRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
