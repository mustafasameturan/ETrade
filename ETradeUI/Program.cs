using DataAccess.Concrete;
using Entities.Concrete;
using ETradeUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ETradeDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ETradeDbContext>();

builder.Services.AddSingleton<APIHelper>();
builder.Services.AddSingleton<HttpClient>();

CookieBuilder cookieBuilder = new CookieBuilder();
cookieBuilder.Name = "ETrade";
cookieBuilder.HttpOnly = true;
cookieBuilder.SameSite = SameSiteMode.Lax;
cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Cookie.HttpOnly = true;
    opts.ExpireTimeSpan = System.TimeSpan.FromDays(60);
    opts.Cookie = cookieBuilder;
    opts.LoginPath = new PathString("/LogIn/Index/");
    opts.AccessDeniedPath = "/ErrorPage/AccessDenied/";
    //opts.LogoutPath = new PathString("");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LogIn}/{action=Index}/{id?}");

app.Run();
