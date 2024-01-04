using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTTBlog.Entity.IdentityEntites;
using NTTBlog.Entity.VM.User;

namespace NTTBlog.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager= signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginVM.Email);
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginVM.Password,userLoginVM.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new {Area ="Admin"});
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya sifreniz hatali");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya sifreniz hatali");
                    return View();
                }
            }
            else
            {
             return  View();

            }
        }

        public IActionResult Errorpage()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home", new {Area=""});
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AccesDenied()
        {
            return View();
        }
    }
}
