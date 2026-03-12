using EmployeeManagementSystem.Modules.Employee.Services;
using EmployeeManagementSystem.Modules.Employee.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            _logger.LogInformation("Employee creation started");
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.CreateEmployeeAsync(model);

                    _logger.LogInformation("Employee created successfully with EmployeeCode {EmployeeCode}", model.EmployeeCode);

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Error occured while creating the employee");

                    return View(model);
                }
            }
            _logger.LogWarning("Employee creation failed due to invalid model.");
            return View(model);
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
            return View(employee);
        }

       



    }
}