using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWZOS.Models;
using SWZOS.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Controllers
{
    public class HomeController : Controller
    {
        private HomeRepository _homeRepository;
        public HomeController(HomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            ViewData.Add("Description", _homeRepository.GetHomePageDescription());
            return View();
        }

        public IActionResult Regulations()
        {
            ViewData.Add("Regulations", _homeRepository.GetRegulations());
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
