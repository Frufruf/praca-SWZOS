using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.Admin;
using SWZOS.Repositories;

namespace SWZOS.Controllers
{
    public class AdminController : Controller
    {
        private HomeRepository _homeRepository;

        public AdminController(HomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GlobalTable()
        {
            var model = _homeRepository.GetAllValues();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditValue(string key)
        {
            var model = _homeRepository.GetModelByKey(key);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditValue(GlobalViewModel model)
        {
            _homeRepository.EditValue(model);
            return RedirectToAction("GlobalTable");
        }
    }
}
