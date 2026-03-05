using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Modules.Dashboard.Controllers
{
    public class DashboardController:Controller
    {

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("UserName");

            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
    }
}
