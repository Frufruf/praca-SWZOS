using Microsoft.AspNetCore.Mvc;
using SWZOS.Models.Equipment;
using SWZOS.Repositories;

namespace SWZOS.Controllers
{
    public class EquipmentController : Controller
    {
        private EquipmentRepository _equipmentRepository;
        public EquipmentController(EquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult Index()
        {
            var model = _equipmentRepository.GetFullEquipment();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EquipmentFormModel model)
        {
            if (ModelState.IsValid)
            {
                _equipmentRepository.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _equipmentRepository.GetEquipmentFormModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EquipmentFormModel model)
        {
            if (ModelState.IsValid)
            {
                _equipmentRepository.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
