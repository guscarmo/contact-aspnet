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
        
        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }
        
        public IActionResult DeleteConfirmation(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _userRepository.Delete(id);

                if (apagado)
                {
                    TempData["MessageSuccess"] = "Usuário excluído!";
                }
                else
                {
                    TempData["MessageError"] = "Não foi possível excluir o usuário!";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível excluir o usuário! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
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
        
        [HttpPost]
        public IActionResult Edit(UserWithoutPasswordModel userWithoutPasswordModel)
        {
            try
            {
                UserModel user = null;
                
                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userWithoutPasswordModel.Id,
                        Name = userWithoutPasswordModel.Name,
                        Login = userWithoutPasswordModel.Login,
                        Email = userWithoutPasswordModel.Email,
                        Perfil = userWithoutPasswordModel.Perfil
                    };
                    
                    user = _userRepository.Update(user);
                    TempData["MessageSuccess"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível alterar o usuário, tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        
        
    }
}