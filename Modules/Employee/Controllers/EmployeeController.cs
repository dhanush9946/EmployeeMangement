using EmployeeManagementSystem.Modules.Employee.Services;
using EmployeeManagementSystem.Modules.Employee.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeManagementSystem.Modules.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        private readonly IMemoryCache _cache;

        //private readonly IDistributedCache _cache2;

        public EmployeeController(IEmployeeService employeeService,
                                  ILogger<EmployeeController> logger,
                                  IMemoryCache cache
                                  //IDistributedCache cache2
                                  )
        {
            _employeeService = employeeService;
            _logger = logger;
            _cache = cache;
            //_cache2 = cache2;

            _cache.Set("EmployeeCount", 100);

            

        }
        

        public async Task<IActionResult> Index()
        {
           
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);

        }

        public async Task<IActionResult> Create()
        {
            var users = await _employeeService.GetAllUsersAsync();

            var model = new CreateEmployeeViewModel
            {
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var users = await _employeeService.GetAllUsersAsync();

                model.Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList();

                return View(model);
            }

            await _employeeService.CreateEmployeeAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Data.Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values)
                {
                    foreach (var subError in error.Errors)
                    {
                        Console.WriteLine(subError.ErrorMessage);
                    }
                }
            }
            return View(employee);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if(emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }


    }
}