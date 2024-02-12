using ASPLab_P.Adjuster;
using Data;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPLab_P.Models
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            var entity = EmployeeAdjuster.ConvertToEntity(employee);
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public List<Employee> FindAll()
        {
            return _context.Employees
                .AsNoTracking()
                .Select(EmployeeAdjuster.ConvertFromEntity)
                .ToList();
        }

        public Employee FindById(int id)
        {
            var entity = _context.Employees.Find(id);
            return entity == null ? null : EmployeeAdjuster.ConvertFromEntity(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _context.Employees.Find(id);
            if (entity != null)
            {
                _context.Employees.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Edit(Employee employee)
        {
            var entity = EmployeeAdjuster.ConvertToEntity(employee);
            _context.Employees.Attach(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<DepartmentEntity> FindAllBranches()
        {
            return _context.Branches.ToList();
        }
    }
}
