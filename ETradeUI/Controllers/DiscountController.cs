using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETradeUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiscountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
