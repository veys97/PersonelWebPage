using Microsoft.AspNetCore.Mvc;
using VeyselAlanWebPage.Models;
using System.IO;
using System.Linq;
using System;

namespace VeyselAlanWebPage.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        // Admin paneli anasayfası (projeleri listeler)
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUsername")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var portfolioItems = _context.PortfolioItems.ToList();
            return View(portfolioItems);
        }

        // Yeni proje ekleme sayfası (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni proje ekleme işlemi (POST)
        [HttpPost]
        public IActionResult Create(PortfolioItem item)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Formu eksiksiz doldurun!";
                return View(item);
            }

            try
            {
                // Veritabanına ekleme işlem
                string dosyaIsmi = item.ImageUrl;
                item.ImageUrl = "/img/" + dosyaIsmi;
                _context.PortfolioItems.Add(item);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Proje başarıyla eklendi!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                return View(item);
            }
        }

        // Proje silme işlemi (GET)
        public IActionResult Delete(int id)
        {
            var item = _context.PortfolioItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item); // Silme onayı için projeyi view'a gönderiyoruz
        }

        // Proje silme işlemi (POST)
      
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.PortfolioItems.Find(id);
            if (item != null)
            {
                _context.PortfolioItems.Remove(item);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Proje başarıyla silindi!";
            }
            return RedirectToAction("Index"); // Silme işleminden sonra Index sayfasına dönüyoruz
        }

        // Proje güncelleme işlemi (GET)
        public IActionResult Edit(int id)
        {
            var item = _context.PortfolioItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // Proje güncelleme işlemi (POST)
        [HttpPost]
        public IActionResult Edit(PortfolioItem p)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Formu eksiksiz doldurun!";
                return View(p);
            }

            var item = _context.PortfolioItems.Find(p.Id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                item.ProjectName = p.ProjectName;
                item.Description = p.Description;
                item.ImageUrl = p.ImageUrl;
                item.Status = p.Status;
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Proje başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                return View(p);
            }
        }
    }
}
