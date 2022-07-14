using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.BlackList;
using SWZOS.Repositories;
using System;
using System.Security.Claims;
using static SWZOS_Database.Enum;

namespace SWZOS.Controllers
{
    public class BlackListController : Controller
    {
        private BlackListRepository _blackListRepository;
        private UsersRepository _usersRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public BlackListController(
            BlackListRepository blackListRepository, 
            UsersRepository usersRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _blackListRepository = blackListRepository;
            _usersRepository = usersRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var model = _blackListRepository.GetBlackListFull();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _blackListRepository.GetBlackListEntry(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddToBlackList(int userId)
        {
            var user = _usersRepository.GetUserSimpleModel(userId);
            return View(new BlackListFormModel { UserId = userId, FullName = user.Name + " " + user.Surname });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult AddToBlackList(BlackListFormModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
                if (role == "Admin")
                {
                    model.StatusId = (int)BlackListStatusEnum.Approved;
                }
                else
                {
                    model.StatusId = (int)BlackListStatusEnum.WaitingForApproval;
                }
                _blackListRepository.AddToBlackList(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFromBlackList(int userId)
        {
            _blackListRepository.DeleteFromBlackList(userId);
            return RedirectToAction("Details", "Users", new { userId = userId });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ApproveBlackListEntry(int userId)
        {
            _blackListRepository.ApproveBlackListEntry(userId);
            return RedirectToAction("Details", "Users", new { userId = userId });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RejectBlackListEntry(int userId)
        {
            _blackListRepository.RejectBlackListEntry(userId);
            return RedirectToAction("Details", "Users", new { userId = userId });
        }
    }
}
