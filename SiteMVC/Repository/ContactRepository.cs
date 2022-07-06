using System.Security.AccessControl;
using SiteMVC.Data;
using SiteMVC.Models;

namespace SiteMVC.Repositorio;

public class ContactRepository : IContactRepository
{
    private readonly BaseContext _baseContext;

    public ContactRepository(BaseContext baseContext)
    {
        _baseContext = baseContext;
    }

    public ContactModel ListById(int id)
    {
        return _baseContext.Contacts.FirstOrDefault(x => x.Id == id);
    }

    public List<ContactModel> FindAll()
    {
        return _baseContext.Contacts.ToList();
    }

    public ContactModel Add(ContactModel contact)
    {
        _baseContext.Contacts.Add(contact);
        _baseContext.SaveChanges();
        return contact;
    }

    public ContactModel Update(ContactModel contact)
    {
        ContactModel contactDB = ListById(contact.Id);

        if (contactDB == null) throw new Exception("Houve um erro na atualização do contato!");

        contactDB.Nome = contact.Nome;
        contactDB.Email = contact.Email;
        contactDB.Celular = contact.Celular;

        _baseContext.Contacts.Update(contactDB);
        _baseContext.SaveChanges();

        return contactDB;

    }

    public bool Delete(int id)
    {
        ContactModel contactDB = ListById(id);
        
        if (contactDB == null) throw new Exception("Houve um erro ao remover o contato!");

        _baseContext.Contacts.Remove(contactDB);
        _baseContext.SaveChanges();

        return true;
    }
}