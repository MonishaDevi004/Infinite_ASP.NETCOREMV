using AutoMapper;
using EKART.DTO;
using EKART.Filters;
using EKART.Models;
using EKART.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//configure the authorization service

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        // Configure other options as needed
    });

// Add authorization services if necessary
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Customer"));
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<NorthwindContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection")));


//create mapperconfiguration 
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

//register the mapping instance to the service container
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<IAuthRepository, AuthService>();

//Register the Exception filter

builder.Services.AddScoped<CustomExceptionFilter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//first middleware
/*app.Use(async (context, next) =>
{

    await context.Response.WriteAsync("I  am the First user define Middleware"+"\n");
    await next(); // call the next middle
    await context.Response.WriteAsync("Called after the seccond Middleware");
});

app.Use(async (context, next) =>
{

    await context.Response.WriteAsync("I  am the second user define Middleware" +"\n");
    await next(); // call the next middle
});

app.Run();
*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//authentication

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
