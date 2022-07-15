using SiteMVC.Models;

namespace SiteMVC.Helper;

public interface ISession
{
    void CreateUserSession(UserModel user);
    void RemoveUserSession();
    UserModel FindUserSession();
}