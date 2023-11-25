using Data_NS2.Migrations;

namespace Laboratorium_3___App.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;
        
        public EFContactService(AppDbContext context)
        {
            _context = context;
        }
        public void AddContact(Contact contact)
        {
            _context.ContactEntities.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = _context.ContactEntities.Find(id);
            if (entity != null)
            {
               _context.ContactEntities.Remove(entity);
            }
        }

        public List<Contact> FindAll()
        {
            return null;
        }

        public Contact? FindById(int id)
        {
            var entity = _context.ContactEntities.Find(id);
            if (entity != null)
            {
                return ContactMapper.FromEntity(entity);
            } else { return null; }
        }

        public void UpdateContact(Contact contact)
        {
            _context.ContactEntities.Update(ContactMapper.ToEntity(contact));
        }
    }
}
