using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GlobalTable()
        {
            var model = _homeRepository.GetAllValues();
            return View(model);
        }
    }
}
