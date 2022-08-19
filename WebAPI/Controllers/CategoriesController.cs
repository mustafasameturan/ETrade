using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getallcategory")]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetList();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycategoryid/{id}")]
        public IActionResult GetByCategoryId(int id)
        {
            var result = _categoryService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            return Ok("category added");
        }

        [HttpDelete("deletecategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.GetById(id);
            _categoryService.Delete(value);
            return Ok("category deleted");
        }

        [HttpPost("updatecategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return Ok("category updated");
        }
    }
}
