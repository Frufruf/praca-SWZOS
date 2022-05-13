using Microsoft.AspNetCore.Mvc;

namespace SWZOS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
