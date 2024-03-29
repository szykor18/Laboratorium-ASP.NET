﻿using Data.Entities;

namespace ASPLab.Models
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        void DeleteById(int id);
        void Edit(Employee employee);
        List<Employee> FindAll();
        Employee? FindById(int id);

        List<BranchEntity> FindAllBranches();
    }
}
