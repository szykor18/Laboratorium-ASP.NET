using ASPLab_P.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPLab_P.Controllers
{
    [Authorize]
    public class BranchOfficeController : Controller
    {
        private readonly IDepartmentService branchManagementService;

        public BranchOfficeController(IDepartmentService service)
        {
            branchManagementService = service;
        }

        [AllowAnonymous]
        public IActionResult Overview()
        {
            var branchOffices = branchManagementService.FindAll();
            return View("Overview", branchOffices); 
        }

        [HttpGet]
        public IActionResult Initiate()
        {
            return View("Create"); 
        }

        [HttpPost]
        public IActionResult Initiate(Department branch) 
        {
            if (ModelState.IsValid)
            {
                branchManagementService.Add(branch);
                return RedirectToAction("Overview");
            }
            return View("Create", branch);
        }

        [HttpGet]
        public IActionResult Modify(int id)
        {
            var branch = branchManagementService.FindById(id);
            if (branch == null) return NotFound();
            return View("Edit", branch); 
        }

        [HttpPost]
        public IActionResult Modify(Department branch)
        {
            if (ModelState.IsValid)
            {
                branchManagementService.Edit(branch);
                return RedirectToAction("Overview");
            }
            return View("Edit", branch);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var branchDetail = branchManagementService.FindById(id);
            return View("Details", branchDetail); 
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var branch = branchManagementService.FindById(id);
            if (branch == null) return NotFound();
            return View("Delete", branch); 
        }

        [HttpPost]
        public IActionResult ConfirmRemoval(Department branch)
        {
            branchManagementService.DeleteById(branch.BranchId);
            return RedirectToAction("Overview");
        }
    }
}
