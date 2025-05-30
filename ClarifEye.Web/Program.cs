using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClarifEye.Web.Extensions;
using ClarifEye.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Configuration
    .AddEnvironmentSpecificJsonFiles(environment, out string connectionString);

builder.Services
    .AddDbContext<ClarifEyeDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ClarifEyeDbContext>()
    .AddUserManager<UserManager<IdentityUser>>()
    .AddSignInManager<SignInManager<IdentityUser>>();

builder.Services
    .RegisterRepositories()
    .RegisterUserDefinedServices();

builder.Services
    .AddControllersWithViews(cfg =>
    {
        cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });

builder.Services
    .AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/User/Login";
    cfg.LogoutPath = "/User/Logout";
});

builder.Services.AddSession(cfg =>
{
    cfg.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();