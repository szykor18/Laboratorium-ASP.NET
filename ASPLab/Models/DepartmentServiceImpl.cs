using ASPLab_P.Adjuster;
using Data;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ASPLab_P.Models
{
    public class DepartmentServiceImpl : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Department branch)
        {
            _context.Branches.Add(DepartmentAdjuster.MapToEntity(branch));
            _context.SaveChanges();
        }

        public List<Department> FindAll()
        {
            return _context.Branches
                .Select(b => DepartmentAdjuster.MapFromEntity(b))
                .ToList();
        }

        public Department FindById(int id)
        {
            var branchEntity = _context.Branches.Find(id);
            if (branchEntity != null)
            {
                return DepartmentAdjuster.MapFromEntity(branchEntity);
            }
            return null;
        }

        public void DeleteById(int id)
        {
            var branch = _context.Branches.Find(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                _context.SaveChanges();
            }
        }

        public void Edit(Department branch)
        {
            _context.Branches.Update(DepartmentAdjuster.MapToEntity(branch));
            _context.SaveChanges();
        }
    }
}
