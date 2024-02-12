using ASPLab_P.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPLab_P.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        private void InitializeBranches(Employee model)
        {
            model.Branches = _employeeService
                .FindAllBranches()
                .Select(o => new SelectListItem() { Value = o.BranchId.ToString(), Text = o.Title })
                .ToList();
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var employees = _employeeService.FindAll();
            var branches = _employeeService.FindAllBranches();
            ViewBag.Branches = branches.ToDictionary(b => b.BranchId, b => b.Title);
            return View(employees);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Employee employee = new Employee();
            InitializeBranches(employee);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }
            InitializeBranches(employee);
            return View(employee);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_employeeService.FindById(id));
        }

        [HttpGet]
        public IActionResult AdvancedEdit(int id)
        {

            return View(_employeeService.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Edit(employee);
                return RedirectToAction("Index");
            }
            InitializeBranches(employee);
            return View(employee);
        }


        public IActionResult Detalis(int id)
        {
            return View(_employeeService.FindById(id));
        }


        [HttpGet]
        public IActionResult Fire(int id)
        {

            return View(_employeeService.FindById(id));
        }

        [HttpPost]
        public IActionResult Fire(Employee employee)
        {
            employee.DateOfDismissal = DateTime.Now;
            _employeeService.Edit(employee);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_employeeService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employeeService.DeleteById(employee.Id);
            return RedirectToAction("Index");
        }
    }
}
