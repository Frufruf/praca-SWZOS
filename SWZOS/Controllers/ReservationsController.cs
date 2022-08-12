using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.Reservations;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SWZOS.Controllers
{
    public class ReservationsController : Controller
    {
        private ReservationsRepository _reservationsRepository;
        private EquipmentRepository _equipmentRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public ReservationsController(ReservationsRepository reservationsRepository,
            EquipmentRepository equipmentRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _reservationsRepository = reservationsRepository;
            _equipmentRepository = equipmentRepository;
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
        public IActionResult AddReservation(int pitchTypeId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pitchEquipment = _equipmentRepository.GetPitchEquipment(pitchTypeId);
            var model = new ReservationFormModel
            {
                UserId = Int32.Parse(userId),
                StartDate = DateTime.Today,
                PitchTypeId = pitchTypeId,
                PitchEquipment = pitchEquipment,
                Duration = 60
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public JsonResult AddReservation(ReservationFormModel model)
        {
            var reservation = _reservationsRepository.ValidateReservation(model, ModelState);
            if (ModelState.IsValid)
            {
                if (reservation != null)
                {
                    try
                    {
                        _reservationsRepository.AddReservation(reservation);
                        return Json(new { success = true });
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error(ex.Message);
                    }
                }
                ModelState.AddModelError("", "Wystąpił nieoczekiwany błąd"); 
            }
            return Json(new { success = false, errors = ModelState.Select(a => a.Value.Errors).Where(a => a.Count > 0).ToList() });
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
