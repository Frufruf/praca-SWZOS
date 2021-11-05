using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var model = new UserFormModel
            {
                IsEditForm = false
            };
            return View("~/Views/Users/UserForm.cshtml", model);
        }

        [HttpPost]
        public JsonResult AddUser(UserFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _usersRepository.AddUser(model);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    return Json(new { success = false, errorMessage = errorMessage });
                }
            }
            return Json(new { success = false });
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
    }
}
