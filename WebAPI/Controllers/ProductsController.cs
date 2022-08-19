using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getallproducts")]
        public IActionResult GetAll()
        {
            var result = _productService.GetList();
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _productService.GetAllDetails();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyproductid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product product)
        {
            _productService.Add(product);
            return Ok("product added");
        }

        [HttpDelete("deleteproduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id);
            _productService.Delete(value);
            return Ok("product deleted");
        }

        [HttpPost("updateproduct")]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return Ok("product updated");
        }

        [HttpPost("discountbycolor")]
        public IActionResult DiscountByColor(int brandId, int categoryId, int colorId, int discountRate)
        {
             _productService.DiscountByColor(brandId, categoryId, colorId, discountRate);
            return Ok("product price updated");
        }

        [HttpPost("discountbysize")]
        public IActionResult DiscountBySize(int brandId, int categoryId, string size, int discountRate)
        {
            _productService.DiscountBySize(brandId, categoryId, size , discountRate);
            return Ok("product price updated");
        }
    }
}
