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

        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }    
        
        public IActionResult Details(int userId)
        {
            var user = _usersRepository.GetUserViewModel(userId);
            return View(user);
        }        

        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            var user = _usersRepository.GetUserFormById(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(UserFormModel model)
        {
            _usersRepository.EditUser(model);
            return RedirectToAction("Details", model.Id);
        }

        public JsonResult DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
