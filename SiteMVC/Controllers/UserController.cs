using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repositorio;


namespace SiteMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.FindAll();
            return View(users);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //verificar se é necessaŕio atribuir à uma variável
                    _userRepository.Add(user);
                    TempData["MessageSuccess"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
            
                return View(user);
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível cadastrar o usuário, tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}