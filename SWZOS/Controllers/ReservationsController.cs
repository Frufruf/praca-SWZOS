using Microsoft.AspNetCore.Mvc;

namespace SWZOS.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditReservation(int reservationId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CancelReservation(int reservationId)
        {
            return RedirectToAction("Index");
        }
    }
}
