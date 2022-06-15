using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.BlackList;
using SWZOS.Models.User;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SWZOS.Controllers
{
    public class UsersController : Controller
    {
        private UsersRepository _usersRepository;
        private BlackListRepository _blackListRepository;

        public UsersController(UsersRepository usersRepository, BlackListRepository blackListRepository)
        {
            _usersRepository = usersRepository;
            _blackListRepository = blackListRepository;
        }

        public IActionResult Index()
        {
            return View();
        }    
        
        public IActionResult Details()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _usersRepository.GetUserViewModelById(Int32.Parse(userId));
            return View(user);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserFormModel model)
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
        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            var user = _usersRepository.GetUserFormById(userId);
            return View(user);
        }

        public JsonResult EditUser(UserFormModel model)
        {
            throw new NotImplementedException();
        }

        public JsonResult DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IActionResult AddToBlackList(int userId)
        {
            return View();
        }

        public IActionResult AddToBlackList(BlackListFormModel model)
        {
            _blackListRepository.AddToBlackList(model);
            //TODO redirect do strony profilu użytkownika
            return RedirectToAction("Index");
        }
    }
}
