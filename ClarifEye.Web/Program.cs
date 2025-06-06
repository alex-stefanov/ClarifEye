using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClarifEye.Web.Extensions;
using ClarifEye.Data;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;
using ClarifEye.Data.Models;

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
    .AddDefaultIdentity<ClarUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ClarifEyeDbContext>()
    .AddUserManager<UserManager<ClarUser>>()
    .AddSignInManager<SignInManager<ClarUser>>();

builder.Services.AddSingleton<OpenAIAPI>(sp =>
{
    var apiKey = builder.Configuration["OpenAI:ApiKey"];
    return new OpenAIAPI(apiKey);
});

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