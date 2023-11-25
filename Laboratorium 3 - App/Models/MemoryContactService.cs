
namespace Laboratorium_3___App.Models
{
    public class MemoryContactService : IContactService
    {
        private readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>()
        {
            { 1, new Contact() {Id = 1, Name= "Adam", Email= "adam@wsei.edu.pl", Phone= "112233445"}},
            { 2, new Contact() {Id = 2, Name= "Ewa", Email= "ewa@wsei.edu.pl", Phone= "998877665"}},
        };
        private int _id = 3;

        public void AddContact(Contact contact)
        {
            contact.Id = _id++;
            _contacts[contact.Id] = contact;   
        }

        public void DeleteById(int id)
        {
            _contacts.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _contacts[id];
        }

        public void UpdateContact(Contact contact)
        {
            int id = contact.Id;
            _contacts[id] = contact;
        }
    }
}
