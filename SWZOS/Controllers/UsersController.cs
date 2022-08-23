using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
using static SWZOS_Database.Enum;

namespace SWZOS.Controllers
{
    public class UsersController : Controller
    {
        private UsersRepository _usersRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UsersController(UsersRepository usersRepository, IHttpContextAccessor httpContextAccessor)
        {
            _usersRepository = usersRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}    

        [Authorize]
        public IActionResult Details(int userId)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var role = currentUser.FindFirstValue(ClaimTypes.Role);
            if (role == "Admin" || role == "Employee" || Int32.Parse(currentUser.FindFirstValue(ClaimTypes.NameIdentifier)) == userId)
            {
                var user = _usersRepository.GetUserViewModel(userId);
                if (user == null)
                {
                    Response.StatusCode = 404;
                }
                return View(user);
            }
            else
            {
                Response.StatusCode = 401;
                return View();
            }
        }        

        [HttpGet]
        [Authorize]
        public IActionResult EditUser(int userId)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var currentUserId = Int32.Parse(currentUser.FindFirstValue(ClaimTypes.NameIdentifier));
            if (currentUserId == userId)
            {
                var user = _usersRepository.GetUserFormById(userId);
                if (user == null)
                {
                    Response.StatusCode = 404;
                }
                return View(user);
            }
            else
            {
                Response.StatusCode = 401;
                return View();
            }
        }

        [HttpPost]
        [Authorize]
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
