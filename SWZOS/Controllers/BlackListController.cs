using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpGet]
        public IActionResult AddToBlackList(int userId)
        {
            return View();
        }
    }
}
