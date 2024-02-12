using ASPLab_P.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPLab_P.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private readonly IEmployeeService staffService;

        public StaffController(IEmployeeService service)
        {
            staffService = service;
        }

        private void PopulateBranchesDropdown(Employee staffMember)
        {
            staffMember.Branches = staffService
                .FindAllBranches()
                .Select(b => new SelectListItem { Value = b.BranchId.ToString(), Text = b.Title })
                .ToList();
        }

        [AllowAnonymous]
        public IActionResult ListAll()
        {
            var staff = staffService.FindAll();
            var branchInfo = staffService.FindAllBranches();
            ViewBag.BranchDetails = branchInfo.ToDictionary(b => b.BranchId, b => b.Title);
            return View("Index", staff); 
        }

        [HttpGet]
        public IActionResult New()
        {
            Employee newStaffMember = new Employee();
            PopulateBranchesDropdown(newStaffMember);
            return View("Create", newStaffMember); 
        }

        [HttpPost]
        public IActionResult New(Employee staffMember)
        {
            if (ModelState.IsValid)
            {
                staffService.Add(staffMember);
                return RedirectToAction("ListAll");
            }
            PopulateBranchesDropdown(staffMember);
            return View("Create", staffMember);
        }

        [HttpGet]
        public IActionResult Adjust(int id)
        {
            var staffMemberToEdit = staffService.FindById(id);
            return View("Edit", staffMemberToEdit); 
        }

        [HttpPost]
        public IActionResult Adjust(Employee staffMember)
        {
            if (ModelState.IsValid)
            {
                staffService.Edit(staffMember);
                return RedirectToAction("ListAll");
            }
            PopulateBranchesDropdown(staffMember);
            return View("Edit", staffMember);
        }

        public IActionResult ViewDetails(int id)
        {
            var staffDetails = staffService.FindById(id);
            return View("Details", staffDetails); 
        }

        [HttpGet]
        public IActionResult Terminate(int id)
        {
            var staffMemberToTerminate = staffService.FindById(id);
            return View("Fire", staffMemberToTerminate); 
        }

        [HttpPost]
        public IActionResult Terminate(Employee staffMember)
        {
            staffMember.DateOfDismissal = DateTime.Now;
            staffService.Edit(staffMember);
            return RedirectToAction("ListAll");
        }

        [HttpGet]
        public IActionResult Erase(int id)
        {
            var staffMemberToRemove = staffService.FindById(id);
            return View("Delete", staffMemberToRemove); 
        }

        [HttpPost]
        public IActionResult Erase(Employee staffMember)
        {
            staffService.DeleteById(staffMember.Id);
            return RedirectToAction("ListAll");
        }
    }
}
