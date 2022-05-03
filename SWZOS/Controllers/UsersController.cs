using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.User;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Controllers
{
    public class UsersController : Controller
    {
        private UsersRepository _usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }        

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserFormModel model)
        {
            _usersRepository.ValidateUserFormModel(model, ModelState); //Walidacja przy tworzeniu konta
            if (ModelState.IsValid)
            {
                try
                {
                    _usersRepository.AddUser(model); //Dodanie użytkownika
                    return RedirectToAction("Login", "Account"); //Przekierowanie na stronę logowania
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    ModelState.AddModelError("", "Wystąpił nieoczekiwany błąd");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            var user = _usersRepository.GetUserById(userId);
            return View("~/Views/Users/UserForm.cshtml", user);
        }

        public JsonResult EditUser(UserFormModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public JsonResult AddToBlackList()
        {
            throw new NotImplementedException();
        }
    }
}
