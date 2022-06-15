using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.Account;
using SWZOS.Models.User;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SWZOS.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepository _accountRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountController(AccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _accountRepository.AuthenticateUser(model);
            if (user != null)
            {
                var userRole = "";
                switch (user.UserTypeId)
                {
                    case 1:
                        userRole = "Admin";
                        break;
                    case 2:
                        userRole = "Employee";
                        break;
                    default:
                        userRole = "Customer";
                        break;
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.MailAddress),
                    new Claim("FullName", user.Name + " " + user.Surname),
                    new Claim(ClaimTypes.Role, userRole),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //TODO RedirectUri
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IssuedUtc = DateTimeOffset.UtcNow,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    IsPersistent = true
                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Wprowadzona nazwa użytkownika, lub hasło jest niepoprawne");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult ChangePassword(PasswordChangeModel model)
        {
            _accountRepository.ValidatePasswordChange(model, ModelState);
            if (ModelState.IsValid)
            {
                _accountRepository.ChangePassword(model);
                //TODO jaki widok zwrócić po zmianie hasła
                return RedirectToAction("Login");
            }
            return View(model);
        }


    }
}
