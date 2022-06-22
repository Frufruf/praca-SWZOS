using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.Pitches;
using SWZOS.Repositories;

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
            if (ModelState.IsValid)
            {
                _pitchesRepository.EditPitch(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
