using Data.Entities;
using System.Collections.Generic;

namespace ASPLab_P.Models
{
    public interface IDepartmentService
    {
        void Add(Department branch);
        void DeleteById(int id);
        void Edit(Department branch);
        List<Department> FindAll();
        Department? FindById(int id);
    }
}
