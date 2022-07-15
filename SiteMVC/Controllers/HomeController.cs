using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Models;

namespace SiteMVC.Controllers;

public class HomeController : Controller
{
    [LoggedUserPage]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}