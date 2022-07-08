using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
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
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Add(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Update(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }
    }
}