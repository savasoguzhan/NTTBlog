using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using NTTBlog.DataAccessLayer.UnitOfWorks;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.Enums;
using NTTBlog.Entity.IdentityEntites;
using NTTBlog.Entity.VM.User;
using NTTBlog.Service.Helpers.ImageHelper;
using System.Data;

namespace NTTBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "MasterAdmin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
            _imageHelper = imageHelper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserVM>>(users);

            foreach (var item in map)
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());

                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); // List turunde oldugu icin teke indirme 

                item.Role = role;
            }
            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(new UserAddVM { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddVM userAddVM)
        {
            var map = _mapper.Map<AppUser>(userAddVM);
            var roles = await _roleManager.Roles.ToListAsync();
            map.UserName = userAddVM.Email;
            map.Firstname = userAddVM.Firstname;
            map.PhoneNumber = userAddVM.PhoneNumber;
            map.LastName = userAddVM.LastName;

            // HATA!!! False Geliyor


            var result = await _userManager.CreateAsync(map, userAddVM.Password);


            var findRole = await _roleManager.FindByIdAsync(userAddVM.RoleId.ToString());
            
            await _userManager.AddToRoleAsync(map, findRole.ToString());
            _toastNotification.AddSuccessToastMessage("New User is Added");
            return RedirectToAction("Index", "User", new { Area = "Admin" });






        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var roles = await _roleManager.Roles.ToListAsync();

            var map = _mapper.Map<UserUpdateVM>(user);

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateVM userUpdateVM)
        {
            var user = await _userManager.FindByIdAsync(userUpdateVM.Id.ToString());

            if (user != null)
            {
                user.Firstname = userUpdateVM.FirstName;
                user.LastName = userUpdateVM.LastName;
                await _userManager.UpdateAsync(user);

            }

            _toastNotification.AddSuccessToastMessage("Succes");


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var map = _mapper.Map<UserProfileVM>(user);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileVM userProfileVM)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            user.Firstname = userProfileVM.FirstName;
            user.LastName = userProfileVM.LastName;
            user.PhoneNumber = userProfileVM.PhoneNumber;

            var imageUpload = await _imageHelper.UpLoad($"{userProfileVM.FirstName}{userProfileVM.LastName}", userProfileVM.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileVM.Photo.ContentType, user.Email);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            user.ImageId=image.Id;
            await _userManager.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
            _toastNotification.AddInfoToastMessage("Profile has been update");
            return View();
        }
    }
}
