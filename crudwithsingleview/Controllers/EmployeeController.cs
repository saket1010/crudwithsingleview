using crudwithsingleview.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudwithsingleview.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_employeeRepository.GetEmployees().ToList());
        }
        [HttpPost]
        public IActionResult AddOrUpdate([Bind("Id,Name,Designation,JoiningDate,Age,Address,Salary,JoiningDate")]
Employee employeeData)
        {
            _employeeRepository.AddOrUpdateEmployee(employeeData);
          
            return View("Index",_employeeRepository.GetEmployees().ToList());
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _employeeRepository.DeleteEmployee(Id);
            return View("Index",_employeeRepository.GetEmployees().ToList());

        }
        public IActionResult Update(int Id)
        {
            ViewData["formempdata"] = _employeeRepository.GetEmployeeById(Id);
            return View("Index", _employeeRepository.GetEmployees().ToList());
        }
    }
}
