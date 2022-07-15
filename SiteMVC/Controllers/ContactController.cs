using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    [LoggedUserPage]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.FindAll();
            return View(contacts);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
        
        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _contactRepository.Delete(id);

                if (apagado)
                {
                    TempData["MessageSuccess"] = "Contato excluído!";
                }
                else
                {
                    TempData["MessageError"] = "Não foi possível excluir o contato!";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível excluir o contato! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contact);
                    TempData["MessageSuccess"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
            
                return View(contact);
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível cadastrar o contato, tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["MessageSuccess"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception e)
            {
                TempData["MessageError"] = $"Não foi possível alterar o contato, tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}