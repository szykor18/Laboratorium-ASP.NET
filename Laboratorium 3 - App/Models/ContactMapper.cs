using Data_NS2.Entities;

namespace Laboratorium_3___App.Models
{
    static public class ContactMapper
    {
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                Email = entity.Email,
                Id = entity.ContactId,
                Name = entity.Name,
                Phone = entity.Phone,
                Birth = entity.Birth,
                Priority = entity.Priority
            };

        }
        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity()
            {
                Email = model.Email,
                ContactId = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Birth = model.Birth,
                Priority = model.Priority
            };
        }
    }
}
