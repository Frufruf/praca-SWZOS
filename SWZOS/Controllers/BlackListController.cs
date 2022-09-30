using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.BlackList;
using SWZOS.Models.Identity.User;
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
        private ReservationsRepository _reservationsRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public BlackListController(
            BlackListRepository blackListRepository, 
            UsersRepository usersRepository,
            ReservationsRepository reservationsRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _blackListRepository = blackListRepository;
            _usersRepository = usersRepository;
            _reservationsRepository = reservationsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Index()
        {
            var model = _blackListRepository.GetBlackListFull();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Approvals()
        {
            var model = _blackListRepository.GetRecordsToApprove();
            return View(model);
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Details(int id)
        {
            var model = _blackListRepository.GetBlackListEntry(id);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult AddToBlackList(int userId)
        {
            var user = _usersRepository.GetUserSimpleModel(userId);
            if (user.UserTypeId == (int)UserTypesEnum.Admin || user.UserTypeId == (int)UserTypesEnum.Employee)
            {
                return RedirectToAction("Index");
            }
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
                    _reservationsRepository.CancelAllUsersReservations(model.UserId);
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFromBlackList(int userId)
        {
            _blackListRepository.DeleteFromBlackList(userId);
            return RedirectToAction("Details", "Users", new { userId = userId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ApproveBlackListEntry(int userId)
        {
            _blackListRepository.ApproveBlackListEntry(userId);
            _reservationsRepository.CancelAllUsersReservations(userId);
            return RedirectToAction("Details", "Users", new { userId = userId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RejectBlackListEntry(int userId)
        {
            _blackListRepository.RejectBlackListEntry(userId);
            return RedirectToAction("Details", "Users", new { userId = userId });
        }

        public JsonResult SearchUsers(UserSearchModel searchModel)
        {
            if (searchModel == null || (String.IsNullOrEmpty(searchModel.Email) 
                && String.IsNullOrEmpty(searchModel.Name) && String.IsNullOrEmpty(searchModel.Surname)))
            {
                return Json(new { success = false, errorMessage = "Nie wprowadzono żadnych wartości" });
            }
            var model = _usersRepository.SearchCustomers(searchModel);
            return Json(new { success = true, users = model });
        }
    }
}
