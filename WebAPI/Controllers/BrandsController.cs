using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getallbrands")]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetList();
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbybrandid/{id}")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _brandService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addbrand")]
        public IActionResult AddBrand(Brand brand)
        {
            _brandService.Add(brand);
            return Ok("brand added");
        }

        [HttpDelete("deletebrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            var value = _brandService.GetById(id);
            _brandService.Delete(value);
            return Ok("brand deleted");
        }

        [HttpPost("updatebrand")]
        public IActionResult UpdateBrand(Brand brand)
        {
            _brandService.Update(brand);
            return Ok("brand updated");
        }

    }
}
