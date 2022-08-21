using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.Account;
using SWZOS.Models.User;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using static SWZOS_Database.Enum;

namespace SWZOS.Controllers
{
    public class AccountController : Controller
    {
        private UsersRepository _usersRepository;
        private AccountRepository _accountRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountController(
            UsersRepository usersRepository,
            AccountRepository accountRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _usersRepository = usersRepository;
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee(UserFormModel model)
        {
            _usersRepository.ValidateUserFormModel(model, ModelState);
            if (ModelState.IsValid)
            {
                try
                {
                    _usersRepository.AddUser(model, (int)UserTypesEnum.Employee);
                    return RedirectToAction("Index", "Admin");
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
                    //TODO potwierdzanie maila
                    _usersRepository.AddUser(model); //Dodanie użytkownika
                    //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
                    //var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink, null);
                    //await _emailSender.SendEmailAsync(message);
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
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            //var user = await _userManager.FindByEmailAsync(email);
            //if (user == null)
            //    return View("Error");
            //var result = await _userManager.ConfirmEmailAsync(user, token);
            //return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
            throw new NotImplementedException();
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
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


    }
}
