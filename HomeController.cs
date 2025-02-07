using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VeyselAlanWebPage.Models;

namespace VeyselAlanWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Portfoy()
        {
            //var d = _context.PortfolioItems.ToList();
            var d = _context.PortfolioItems.Where(x => x.Status == "Aktif").ToList() ;
            return View(d);
        }
    }
}
