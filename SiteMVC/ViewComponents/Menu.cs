using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteMVC.Models;


namespace SiteMVC.ViewComponents;

public class Menu : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string userSession = HttpContext.Session.GetString("userSessionLogged");

        if (string.IsNullOrEmpty(userSession)) return null;

        UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
        
        return View(user);
    }
}