using EmployeeManagementSystem.Modules.Employee.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Modules.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}