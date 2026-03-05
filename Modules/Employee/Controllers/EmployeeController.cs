using EmployeeManagementSystem.Modules.Employee.Services;
using EmployeeManagementSystem.Modules.Employee.ViewModels;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployeeAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}