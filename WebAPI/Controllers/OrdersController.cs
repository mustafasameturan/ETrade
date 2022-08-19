using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getallorders")]
        public IActionResult GetAllBrands()
        {
            var result = _orderService.GetList();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyorderid/{id}")]
        public IActionResult GetByOrderId(int id)
        {
            var result = _orderService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addbrand")]
        public IActionResult AddOrder(Order order)
        {
            _orderService.Add(order);
            return Ok("order added");
        }

        [HttpDelete("deleteorder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.GetById(id);
            _orderService.Delete(value);
            return Ok("order deleted");
        }

        [HttpPost("updateorder")]
        public IActionResult UpdateOrder(Order order)
        {
            _orderService.Update(order);
            return Ok("order updated");
        }
    }
}
