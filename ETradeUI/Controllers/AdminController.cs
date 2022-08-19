using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETradeUI.Controllers
{
    [Authorize(Roles = "SysAdmin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //sysadmin - Sysadmin034.
        //admin - Admin034.
    }
}
