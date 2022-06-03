using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.Reservations;
using SWZOS.Repositories;
using System;

namespace SWZOS.Controllers
{
    public class ReservationsController : Controller
    {
        private ReservationsRepository _reservationsRepository;
        public ReservationsController(ReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReservation(ReservationFormModel model)
        {
            var reservation = _reservationsRepository.ValidateReservation(model, ModelState);
            if (ModelState.IsValid)
            {
                try
                {
                    _reservationsRepository.AddReservation(reservation);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    ModelState.AddModelError("", "Wystąpił nieoczekiwany błąd");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditReservation(int reservationId)
        {
            var model = _reservationsRepository.GetReservationById(reservationId);
            return View(model);
        }

        [HttpPost]
        public IActionResult CancelReservation(int reservationId)
        {
            _reservationsRepository.CancelReservation(reservationId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteReservation(int reservationId)
        {
            _reservationsRepository.DeleteReservaion(reservationId);
            return RedirectToAction("Index");
        }
    }
}
