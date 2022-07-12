using System.Security.AccessControl;
using SiteMVC.Data;
using SiteMVC.Models;

namespace SiteMVC.Repositorio;

public class UserRepository : IUserRepository
{
    private readonly BaseContext _baseContext;

    public UserRepository(BaseContext baseContext)
    {
        _baseContext = baseContext;
    }

    public UserModel ListById(int id)
    {
        return _baseContext.Users.FirstOrDefault(x => x.Id == id);
    }

    public List<UserModel> FindAll()
    {
        return _baseContext.Users.ToList();
    }

    public UserModel Add(UserModel user)
    {
        user.RegistrationDate = DateTime.Now;
        _baseContext.Users.Add(user);
        _baseContext.SaveChanges();
        return user;
    }

    public UserModel Update(UserModel user)
    {
        UserModel userDB = ListById(user.Id);

        if (userDB == null) throw new Exception("Houve um erro na atualização do Usuário!");

        userDB.Name = user.Name;
        userDB.Email = user.Email;
        userDB.Login = user.Login;
        userDB.Perfil = user.Perfil;
        userDB.RegistrationDate = DateTime.Now;

        _baseContext.Users.Update(userDB);
        _baseContext.SaveChanges();

        return userDB;

    }

    public bool Delete(int id)
    {
        UserModel userDB = ListById(id);
        
        if (userDB == null) throw new Exception("Houve um erro ao remover o usuário!");

        _baseContext.Users.Remove(userDB);
        _baseContext.SaveChanges();

        return true;
    }
}