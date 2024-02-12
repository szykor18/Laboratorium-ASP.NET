using ASPLab_P.Models;
using Data.Entities;

namespace ASPLab_P.Mappers
{
    public class BranchMapper
    {
        public static Branch FromEntity(BranchEntity entity)
        {
            return new Branch()
            {
                BranchId = entity.BranchId,
                Title = entity.Title,
                City = entity.Address.City,
                Street = entity.Address.Street,
                Number = entity.Address.Number,
                PostalCode = entity.Address.PostalCode,
                Region = entity.Address.Region,
                Country = entity.Address.Country
            };
        }

        public static BranchEntity ToEntity(Branch model)
        {
            return new BranchEntity()
            {
                BranchId = model.BranchId,
                Title = model.Title,
                Address = new Address
                {
                    City = model.City,
                    Street = model.Street,
                    Number = model.Number,
                    PostalCode = model.PostalCode,
                    Region = model.Region,
                    Country = model.Country
                }
            };
        }
    }
}
