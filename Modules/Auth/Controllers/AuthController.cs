using EmployeeManagementSystem.Modules.Auth.Services;
using EmployeeManagementSystem.Modules.Auth.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagementSystem.Modules.Auth.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService,
                              ILogger<AuthController> logger)
        {
            this.authService = authService;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation("Login attempt by email {Email}", model.Email);
            
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Login Attempt for email {Email}", model.Email);
                return View(model);
            }

            var user = await authService.LoginAsync(model.Email, model.Password);

            if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View(model);
            }

            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserRole", user.Role);

            _logger.LogInformation("User {Email} login successfullly", model.Email);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}