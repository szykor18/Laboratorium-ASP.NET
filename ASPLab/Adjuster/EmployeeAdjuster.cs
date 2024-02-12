using ASPLab_P.Models;
using Data.Entities;

namespace ASPLab_P.Adjuster
{
    public class EmployeeAdjuster
    {
        public static Employee ConvertFromEntity(EmployeeEntity input)
        {
            return new Employee()
            {
                Id = input.EmployeeId,
                Name = input.Name,
                LastName = input.LastName,
                PESEL = input.PESEL,
                Email = input.Email,
                Phone = input.Phone,
                Position = (Role)input.Position,
                BranchId = input.BranchId,
                DateOfEmployment = input.DateOfEmployment,
                DateOfDismissal = input.DateOfDismissal,
            };
        }

        public static EmployeeEntity ConvertToEntity(Employee output)
        {
            return new EmployeeEntity()
            {
                EmployeeId = output.Id,
                Name = output.Name,
                LastName = output.LastName,
                PESEL = output.PESEL,
                Email = output.Email,
                Phone = output.Phone,
                Position = (int)output.Position,
                BranchId = output.BranchId,
                DateOfEmployment = output.DateOfEmployment,
                DateOfDismissal = output.DateOfDismissal,
            };
        }
    }
}
