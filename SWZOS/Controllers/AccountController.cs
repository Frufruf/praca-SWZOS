using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.Account;
using SWZOS.Models.User;
using SWZOS.Repositories;
using System;

namespace SWZOS.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepository _accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var result = _accountRepository.AuthenticateUser(model);
            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Wprowadzona nazwa użytkownika, lub hasło jest niepoprawne");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(PasswordChangeModel model)
        {
            _accountRepository.ValidatePasswordChange(model, ModelState);
            if (ModelState.IsValid)
            {
                _accountRepository.ChangePassword(model);
                //TODO Wyloguj użytkownika i przekieruj na stronę logowania
                return RedirectToAction("Login");
            }
            return View(model);
        }


    }
}
