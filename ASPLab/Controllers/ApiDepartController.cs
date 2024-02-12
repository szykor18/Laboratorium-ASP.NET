using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLab_P.Controllers
{
    [Route("api/branch-info")]
    [ApiController]
    public class ApiDepartController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ApiDepartController(AppDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult FetchBranches(string? nameFilter)
        {
            var query = dbContext.Branches.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                nameFilter = nameFilter.ToLower();
                query = query.Where(b => b.Title.ToLower().Contains(nameFilter));
            }

            var result = query.Select(b => new { b.Title, b.BranchId, b.Address }).ToList();
            return Ok(result);
        }
    }
}
