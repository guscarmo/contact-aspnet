using SiteMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SiteMVC.Helper;

public class Session : ISession
{
    private readonly IHttpContextAccessor _httpContext;

    public Session(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }
    
    public void CreateUserSession(UserModel user)
    {
        string value = JsonConvert.SerializeObject(user);
        _httpContext.HttpContext.Session.SetString("userSessionLogged", value);
    }

    public void RemoveUserSession()
    {
        _httpContext.HttpContext.Session.Remove("userSessionLogged");
    }

    public UserModel FindUserSession()
    {
        string userSession = _httpContext.HttpContext.Session.GetString("userSessionLogged");

        if (string.IsNullOrEmpty(userSession)) return null;

        return JsonConvert.DeserializeObject<UserModel>(userSession);
    }
}