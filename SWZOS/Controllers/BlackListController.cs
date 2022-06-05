using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.BlackList;
using SWZOS.Repositories;

namespace SWZOS.Controllers
{
    public class BlackListController : Controller
    {
        private BlackListRepository _blackListRepository;
        public BlackListController(BlackListRepository blackListRepository)
        {
            _blackListRepository = blackListRepository;
        }

        public IActionResult Index()
        {
            var model = _blackListRepository.GetBlackListFull();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddToBlackList(int userId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToBlackList(BlackListFormModel model)
        {
            if (ModelState.IsValid)
            {
                _blackListRepository.AddToBlackList(model);
            }
            return View();
        }
    }
}
