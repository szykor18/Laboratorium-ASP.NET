using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLab_P.Controllers
{
    [Route("api/branches")]
    [ApiController]
    public class BranchApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BranchApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFiltered(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return Ok(_context.Branches.AsNoTracking()
                    .Select(o => new { o.Title, o.BranchId, o.Address })
                    .ToList());
            }

            title = title.ToLower();

            return Ok(_context.Branches.AsNoTracking()
                .Where(o => o.Title.ToLower().Contains(title))
                .Select(o => new { o.Title, o.BranchId, o.Address })
                .ToList());
        }
    }
}
