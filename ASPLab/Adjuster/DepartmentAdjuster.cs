using ASPLab_P.Models;
using Data.Entities;

namespace ASPLab_P.Adjuster
{
    public class DepartmentAdjuster
    {
        public static Department MapFromEntity(DepartmentEntity source)
        {
            return new Department()
            {
                BranchId = source.BranchId,
                Title = source.Title,
                City = source.Address.City,
                Street = source.Address.Street,
                Number = source.Address.Number,
                PostalCode = source.Address.PostalCode,
                Region = source.Address.Region,
                Country = source.Address.Country
            };
        }

        public static DepartmentEntity MapToEntity(Department target)
        {
            return new DepartmentEntity()
            {
                BranchId = target.BranchId,
                Title = target.Title,
                Address = new Address
                {
                    City = target.City,
                    Street = target.Street,
                    Number = target.Number,
                    PostalCode = target.PostalCode,
                    Region = target.Region,
                    Country = target.Country
                }
            };
        }
    }
}
