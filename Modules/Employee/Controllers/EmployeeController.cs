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

        private readonly IDistributedCache _cache2;

        public EmployeeController(IEmployeeService employeeService,
                                  ILogger<EmployeeController> logger,
                                  IMemoryCache cache,
                                  IDistributedCache cache2)
        {
            _employeeService = employeeService;
            _logger = logger;
            _cache = cache;
            _cache2 = cache2;

            _cache.Set("EmployeeCount", 100);

            

        }
        

        public async Task<IActionResult> Index()
        {
            await _cache2.SetStringAsync("EmployeeCount", "150");
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

        public IActionResult TestError()
        {
            int x = 10;
            int y = 0;

            int result = x / y; // Exception

            return View();
        }


        public async Task<IActionResult> EmployeeCount()
        {
            var count = await _cache2.GetStringAsync("EmployeeCount");

            if (count == null)
            {
                count = "No value in Redis";
            }

            return Content($"Employee Count from Redis: {count}");
        }

    }
}