using Entities.Concrete;
using Entities.DTOs;
using ETradeUI.Helpers;
using ETradeUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ETradeUI.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly APIHelper _apiHelper;
        private HttpClient _httpClient;

        public HomeController(UserManager<AppUser> userManager, APIHelper apiHelper, HttpClient httpClient, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _apiHelper = apiHelper;
            _httpClient = _apiHelper.Initial();
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //Aktif kullanıcı rolünü listeleme kodu.
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IList<string> role = await _userManager.GetRolesAsync(user);
            foreach(var roleItem in role)
            {
                ViewBag.Role = roleItem;
            }

            //Ürün bilgilerini API'den alarak listeleme kodu.
            List<ProductDto> products = new List<ProductDto>();
            var response = await _httpClient.GetAsync("products/getalldetails");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductDto>>(apiResponse);
            }
            return View(products);
        }
    }
}