using ASPLab_P.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPLab_P.Controllers
{
    [Authorize]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var branches = _branchService.FindAll();
            return View(branches);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchService.Add(branch);
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var branch = _branchService.FindById(id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        [HttpPost]
        public IActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchService.Edit(branch);
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        [HttpGet]
        public IActionResult Detalis(int id)
        {
            var branch = _branchService.FindById(id);
            return View(branch);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var branch = _branchService.FindById(id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        [HttpPost]
        public IActionResult Delete(Branch branch)
        {
            _branchService.DeleteById(branch.BranchId);
            return RedirectToAction("Index");
        }
    }
}
