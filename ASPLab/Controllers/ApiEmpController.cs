using Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPLab_P.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class ApiEmpControlller : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ApiEmpControlller(AppDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult FetchEmployees(string? branchIdFilter)
        {
            var query = dbContext.Employees;

            if (!string.IsNullOrWhiteSpace(branchIdFilter))
            {
                int branchId = int.Parse(branchIdFilter);
                query = (Microsoft.EntityFrameworkCore.DbSet<Data.Entities.EmployeeEntity>)query.Where(e => e.BranchId == branchId);
            }

            var result = query.Select(e => new {
                e.EmployeeId,
                e.Name,
                e.LastName,
                e.PESEL,
                e.Email,
                e.Phone,
                e.Position,
                e.BranchId,
                e.DateOfEmployment,
                e.DateOfDismissal
            }).ToList();
            return Ok(result);
        }
    }
}
