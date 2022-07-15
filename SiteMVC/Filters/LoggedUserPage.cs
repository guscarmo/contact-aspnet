using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SiteMVC.Models;

namespace SiteMVC.Filters;

public class LoggedUserPage : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string userSession = context.HttpContext.Session.GetString("userSessionLogged");

        if (string.IsNullOrEmpty(userSession))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary{ {"controller", "Login"}, {"action", "Index" } });
        }
        else
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{ {"controller", "Login"}, {"action", "Index" } });
            }
        }
        
        base.OnActionExecuting(context);
    }
}