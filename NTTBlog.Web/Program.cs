using Microsoft.EntityFrameworkCore;
using NTTBlog.DataAccessLayer.Extensions;
using NTTDATA.DataAccessLayer.Context;
using NTTBlog.Service.Extension;
using NTTBlog.Entity.IdentityEntites;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDALExtension(builder.Configuration).LoadServiceLayerDI();


// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
{
    PositionClass= ToastPositions.TopRight,
    TimeOut=3500,

}).AddRazorRuntimeCompilation();
builder.Services.AddSession();


builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<UygulamaDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/logut");
    config.Cookie = new CookieBuilder
    {
        Name = "NTTBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest   //http ve htpps
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(10);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccesDenied");
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapDefaultControllerRoute();
});

app.Run();
