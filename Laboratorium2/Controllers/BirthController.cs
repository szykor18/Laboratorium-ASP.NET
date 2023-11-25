using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(Birth model)
        {
            if (!model.IsValid())
            {
                return BadRequest("Invalid input data.");
            }
            return View(model);
        }
    }
}
