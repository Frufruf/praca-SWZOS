﻿using Microsoft.AspNetCore.Authorization;
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
        private PitchesRepository _pitchesRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public ReservationsController(ReservationsRepository reservationsRepository,
            EquipmentRepository equipmentRepository,
            PitchesRepository pitchesRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _reservationsRepository = reservationsRepository;
            _equipmentRepository = equipmentRepository;
            _pitchesRepository = pitchesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var model = new ReservationsPageViewModel
            {
                StartDate = startDate != null ? (DateTime)startDate : DateTime.Now,
                EndDate = endDate != null ? (DateTime)endDate : DateTime.Now
            };
            if (role == "Admin" || role == "Employee")
            {
                if (startDate != null && endDate != null)
                {
                    model.Reservations = _reservationsRepository.GetReservationsByDate((DateTime)startDate, (DateTime)endDate);
                }
                else
                {
                    model.Reservations = _reservationsRepository.GetReservationsByDate(DateTime.Now, DateTime.Now);
                }
            }
            else
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (startDate != null && endDate != null)
                {
                    model.Reservations = _reservationsRepository.GetUserReservations(Int32.Parse(userId), (DateTime)startDate, (DateTime)endDate);
                }
                else
                {
                    model.Reservations = _reservationsRepository.GetUserReservations(Int32.Parse(userId), DateTime.Now, DateTime.Now);
                }
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
                StartDate = DateTime.Today.AddHours(10),
                PitchTypeId = pitchTypeId,
                PitchEquipment = pitchEquipment,
                Duration = 60,
                PitchPrice = _pitchesRepository.GetPitchPrice(pitchTypeId)
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
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).ToList() });
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditReservation(int reservationId)
        {
            var model = _reservationsRepository.GetReservationById(reservationId);
            model.IsEditForm = true;
            return View(model);
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public JsonResult CancelReservation(int reservationId)
        {
            var userId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var success = false;
            if (role == "Admin" || role == "Employee")
            {
                success = _reservationsRepository.CancelReservation(reservationId, userId, true);
            }
            else
            {
                success = _reservationsRepository.CancelReservation(reservationId, userId);
            }
            return Json(success);
        }

    }
}
