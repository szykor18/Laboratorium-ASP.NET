using Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPLab_P.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFiltered(string? BranchId)
        {
            if (string.IsNullOrWhiteSpace(BranchId))
            {
                return Ok(_context.Employees
                    .Select(o => new { o.EmployeeId, o.Name, o.LastName, o.PESEL, o.Email, o.Phone, o.Position, o.BranchId, o.DateOfEmployment, o.DateOfDismissal })
                    .ToList());
            }

            BranchId = BranchId;

            return Ok(_context.Employees
                .Where(o => o.BranchId == int.Parse(BranchId))
                .Select(o => new { o.EmployeeId, o.Name, o.LastName, o.PESEL, o.Email, o.Phone, o.Position, o.BranchId, o.DateOfEmployment, o.DateOfDismissal })
                .ToList());
        }
    }
}
