using E_Store.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CleanStoreDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Users/LoginView"; // Đường dẫn đến trang đăng nhập nếu chưa login
        options.AccessDeniedPath = "/Users/LoginView"; // Trang hiển thị nếu không đủ quyền (Role)
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Thời gian sống của Cookie
    });
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

// Cho phép sử dụng Authentication và Authorization trong pipeline
app.UseAuthentication(); // Kích hoạt Authentication
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "/{controller}/{action}/{id:int?}");

app.Run();
