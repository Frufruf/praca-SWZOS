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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditPitchType(int typeId)
        {
            var model = _pitchesRepository.GetPitchType(typeId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPitchType(PitchTypeModel model)
        {
            if (ModelState.IsValid)
            {
                _pitchesRepository.EditPitchType(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditPitch(int pitchId)
        {
            var model = _pitchesRepository.GetPitch(pitchId);
            return View(model);
        }

        [HttpPost]
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
                    ModelState.AddModelError("", "W trakcie edycji boiska wystąpił nieoczekiwany błąd, skontaktuj się z administratorem systemu");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
