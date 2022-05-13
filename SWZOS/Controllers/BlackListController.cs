using Microsoft.AspNetCore.Mvc;

namespace SWZOS.Controllers
{
    public class BlackListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddToBlackList()
        {
            return View();
        }
    }
}
