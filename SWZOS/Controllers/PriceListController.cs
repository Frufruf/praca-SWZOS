using Microsoft.AspNetCore.Mvc;
using SWZOS.Repositories;

namespace SWZOS.Controllers
{
    public class PriceListController : Controller
    {
        private PriceListRepository _priceListRepository;
        public PriceListController(PriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }

        public IActionResult Index()
        {
            var model = _priceListRepository.GetPriceListFull();
            return View(model);
        }

    }
}
