using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getallcolors")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetList();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycolorid/{id}")]
        public IActionResult GetByColorId(int id)
        {
            var result = _colorService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addcolor")]
        public IActionResult AddColor(Color color)
        {
            _colorService.Add(color);
            return Ok("color added");
        }

        [HttpDelete("deletecolor/{id}")]
        public IActionResult DeleteColor(int id)
        {
            var value = _colorService.GetById(id);
            _colorService.Delete(value);
            return Ok("color deleted");
        }

        [HttpPost("updatecolor")]
        public IActionResult UpdateColor(Color color)
        {
            _colorService.Update(color);
            return Ok("color updated");
        }
    }
}
