using Data.Entities;
using System.Collections.Generic;

namespace ASPLab_P.Models
{
    public interface IBranchService
    {
        void Add(Branch branch);
        void DeleteById(int id);
        void Edit(Branch branch);
        List<Branch> FindAll();
        Branch? FindById(int id);
    }
}
