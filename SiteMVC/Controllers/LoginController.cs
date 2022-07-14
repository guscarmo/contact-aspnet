using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;
        
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    UserModel user = _userRepository.FindByLogin(loginModel.Login);
                    
                    if (user != null)
                    {
                        if (user.ValidPassword(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");    
                        }
                        
                        TempData["MessageError"] = $"Senha inválida, tente novamente.";
                    }
                    
                    TempData["MessageError"] = $"Usuário e/ou senha inválido(s), tente novamente.";
                }
                
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível realizar o login, tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}