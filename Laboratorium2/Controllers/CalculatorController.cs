using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Result(Operators? op,
            [FromQuery(Name = "a")]double?x,
            [FromQuery(Name = "b")]double? y)
        {
            if (op == null || x == null || y == null)
            {
                return View("Error");
            }
            switch (op)
            {
                case Operators.ADD:
                    ViewBag.op = x + y;
                    break;
                case Operators.SUB:
                    ViewBag.op = x - y;
                    break;
                case Operators.MUL:
                    ViewBag.op = x * y;
                    break;
                case Operators.DIV:
                    ViewBag.op = x / y;
                    break;
                case Operators.EXP:
                    int exp = 1;
                    for (int i = 0; i < y; i++)
                    {
                        exp = (int)(exp * x);
                    }
                    ViewBag.op = exp;
                    break;
            }

            return View();
        }
        public IActionResult Result(Calculator model)
        {
            if(model.isValid())
            {
                return BadRequest();
            }
        }
    }
}
