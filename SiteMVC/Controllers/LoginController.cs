using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repositorio;
using ISession = SiteMVC.Helper.ISession;

namespace SiteMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISession _session;
        
        public LoginController(IUserRepository userRepository,
                                ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }
        public IActionResult Index()
        {
            // Se o usuário estiver logado, redirecionar para a Home
            if (_session.FindUserSession() != null) return RedirectToAction("Index","Home");
            return View();
        }

        public IActionResult Logout()
        {
            _session.RemoveUserSession();

            return RedirectToAction("Index", "Login");
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
                            _session.CreateUserSession(user);
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