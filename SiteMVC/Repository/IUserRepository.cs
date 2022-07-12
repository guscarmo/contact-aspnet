using SiteMVC.Models;

namespace SiteMVC.Repositorio;

public interface IUserRepository
{
    UserModel ListById(int id);
    List<UserModel> FindAll();
    UserModel Add(UserModel user);
    UserModel Update(UserModel user);
    bool Delete(int id);
}