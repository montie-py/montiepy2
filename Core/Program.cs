using Microsoft.AspNetCore.Authentication.Cookies;
using montiepy2.Business.Services.Blog;
using montiepy2.Business.Services.Review;
using montiepy2.Core.Middlewares;
using montiepy2.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
//switch on sessions
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IResumeService, ResumeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//using sessions
app.UseSession();

//using middlewares
app.UseMiddleware<SessionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();