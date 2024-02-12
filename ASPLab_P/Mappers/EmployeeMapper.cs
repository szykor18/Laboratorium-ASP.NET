using ASPLab_P.Models;
using Data.Entities;

namespace ASPLab_P.Mappers
{
    public class EmployeeMapper
    {
        public static Employee FromEntity(EmployeeEntity entity)
        {
            return new Employee()
            {
                Id = entity.EmployeeId,
                Name = entity.Name,
                LastName = entity.LastName,
                PESEL = entity.PESEL,
                Email = entity.Email,
                Phone = entity.Phone,
                Position = (Position)entity.Position,
                BranchId = entity.BranchId,
                DateOfEmployment = entity.DateOfEmployment,
                DateOfDismissal = entity.DateOfDismissal,
            };
        }

        public static EmployeeEntity ToEntity(Employee model)
        {
            return new EmployeeEntity()
            {
                EmployeeId = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                PESEL = model.PESEL,
                Email = model.Email,
                Phone = model.Phone,
                Position = (int)model.Position,
                BranchId = model.BranchId,
                DateOfEmployment = model.DateOfEmployment,
                DateOfDismissal = model.DateOfDismissal,
            };
        }
    }
}
