using Microsoft.AspNetCore.Mvc;

namespace ETradeUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
