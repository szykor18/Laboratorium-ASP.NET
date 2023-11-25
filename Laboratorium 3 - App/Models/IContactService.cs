namespace Laboratorium_3___App.Models
{
    public interface IContactService
    {
        void AddContact(Contact contact);   
        void UpdateContact(Contact contact);

        void DeleteById(int id);
        Contact? FindById(int id);
        List<Contact> FindAll();
    }
}
