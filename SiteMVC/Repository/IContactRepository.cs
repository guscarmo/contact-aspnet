using SiteMVC.Models;

namespace SiteMVC.Repositorio;

public interface IContactRepository
{
    ContactModel ListById(int id);
    List<ContactModel> FindAll();
    ContactModel Add(ContactModel contact);
    ContactModel Update(ContactModel contact);
    bool Delete(int id);
}