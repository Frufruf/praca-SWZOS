using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.User;
using System;

namespace SWZOS.Controllers
{
    public class AccountController : Controller
    {
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
    }
}
