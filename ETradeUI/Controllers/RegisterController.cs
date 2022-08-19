using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETradeUI.Controllers
{
    //Herkesin erişebildiği sayfa.
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto register)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = register.UserName;
                user.Name = register.Name;
                user.Surname = register.Surname;
                user.Email = register.Email;
                user.PhoneNumber = register.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    return RedirectToAction("Index", "LogIn");
                }
                else
                {
                    foreach(IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(register);
        }
    }
}
