using ASPLab_P.Mappers;
using Data;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ASPLab_P.Models
{
    public class EFBranchService : IBranchService
    {
        private readonly AppDbContext _context;

        public EFBranchService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Branch branch)
        {
            _context.Branches.Add(BranchMapper.ToEntity(branch));
            _context.SaveChanges();
        }

        public List<Branch> FindAll()
        {
            return _context.Branches
                .Select(b => BranchMapper.FromEntity(b))
                .ToList();
        }

        public Branch FindById(int id)
        {
            var branchEntity = _context.Branches.Find(id);
            if (branchEntity != null)
            {
                return BranchMapper.FromEntity(branchEntity);
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

        public void Edit(Branch branch)
        {
            _context.Branches.Update(BranchMapper.ToEntity(branch));
            _context.SaveChanges();
        }
    }
}
