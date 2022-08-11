using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.Reservations;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SWZOS.Controllers
{
    public class ReservationsController : Controller
    {
        private ReservationsRepository _reservationsRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public ReservationsController(ReservationsRepository reservationsRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _reservationsRepository = reservationsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        public IActionResult Index()
        {
            var role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var model = new List<ReservationsViewModel>();
            if (role == "Admin" || role == "Employee")
            {
                model = _reservationsRepository.GetReservationsByDate(DateTime.Now, DateTime.Now);
            }
            else
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                model = _reservationsRepository.GetUserReservations(Int32.Parse(userId));
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddReservation()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(new ReservationFormModel { UserId = Int32.Parse(userId) });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddReservation(ReservationFormModel model)
        {
            var reservation = _reservationsRepository.ValidateReservation(model, ModelState);
            if (ModelState.IsValid)
            {
                if (reservation != null)
                {
                    try
                    {
                        _reservationsRepository.AddReservation(reservation);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error(ex.Message);
                    }
                }
                ModelState.AddModelError("", "Wystąpił nieoczekiwany błąd");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditReservation(int reservationId)
        {
            var model = _reservationsRepository.GetReservationById(reservationId);
            model.IsEditForm = true;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditReservation(ReservationFormModel model)
        {
            var reservation = _reservationsRepository.ValidateReservation(model, ModelState);
            if (ModelState.IsValid)
            {
                if (reservation != null)
                {
                    try
                    {
                        _reservationsRepository.EditReservation(reservation);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error(ex.Message);
                    }
                }
                ModelState.AddModelError("", "Wystąpił nieoczekiwany błąd");
                return View(model);
            }
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
