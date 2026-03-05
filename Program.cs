using EmployeeManagementSystem.Data.Models;
using EmployeeManagementSystem.Modules.Auth.Repositories;
using EmployeeManagementSystem.Modules.Auth.Services;
using EmployeeManagementSystem.Modules.Employee.Repository;
using EmployeeManagementSystem.Modules.Employee.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews()
.AddRazorOptions(options =>
{
    options.ViewLocationFormats.Add("/Modules/{1}/Views/{1}/{0}.cshtml");
    options.ViewLocationFormats.Add("/Modules/{1}/Views/{0}.cshtml");

    // Root shared views
    options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();