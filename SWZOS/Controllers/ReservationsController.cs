using Microsoft.AspNetCore.Mvc;

namespace SWZOS.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
