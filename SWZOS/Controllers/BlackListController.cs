using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.BlackList;
using SWZOS.Repositories;
using System;

namespace SWZOS.Controllers
{
    public class BlackListController : Controller
    {
        private BlackListRepository _blackListRepository;
        private UsersRepository _usersRepository;

        public BlackListController(BlackListRepository blackListRepository, UsersRepository usersRepository)
        {
            _blackListRepository = blackListRepository;
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            var model = _blackListRepository.GetBlackListFull();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddToBlackList(int userId)
        {
            var user = _usersRepository.GetUserSimpleModel(userId);
            return View(new BlackListFormModel { UserId = userId, FullName = user.Name + " " + user.Surname });
        }

        [HttpPost]
        public IActionResult AddToBlackList(BlackListFormModel model)
        {
            if (ModelState.IsValid)
            {
                _blackListRepository.AddToBlackList(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(BlackListFormModel model)
        {
            throw new NotImplementedException();
        }
    }
}
