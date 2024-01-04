using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTTBlog.Entity.IdentityEntites;

namespace NTTBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            return View(loggedInUser);
        }
    }
}
