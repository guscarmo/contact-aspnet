using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;

namespace SiteMVC.Controllers
{
    public class RestrictedController : Controller
    {
        [LoggedUserPage]
        
        public IActionResult Index()
        {
            return View();
        }
    }
}