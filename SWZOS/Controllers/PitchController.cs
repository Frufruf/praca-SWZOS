﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SWZOS.Models.Pitches;
using SWZOS.Repositories;
using System;

namespace SWZOS.Controllers
{
    public class PitchController : Controller
    {
        private PitchesRepository _pitchesRepository;

        public PitchController(PitchesRepository pitchesRepository)
        {
            _pitchesRepository = pitchesRepository;
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Index()
        {
            var model = _pitchesRepository.GetAllPitches();
            return View(model);
        }

        //public IActionResult Details(int pitchId)
        //{
        //    return View();
        //}

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditPitchType(int typeId)
        {
            var model = _pitchesRepository.GetPitchType(typeId);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditPitchType(PitchTypeModel model)
        {
            if (ModelState.IsValid && model.PitchTypePrice > 0.00)
            {
                _pitchesRepository.EditPitchType(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult EditPitch(int pitchId)
        {
            var model = _pitchesRepository.GetPitch(pitchId);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult EditPitch(PitchModel model)
        {
            _pitchesRepository.ValidateEditPitchModel(model, ModelState);
            if (ModelState.IsValid)
            {
                try
                {
                    _pitchesRepository.EditPitch(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    ModelState.AddModelError("", "W trakcie edycji boiska wystąpił nieoczekiwany błąd, " +
                        "skontaktuj się z administratorem systemu");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
