using Microsoft.AspNetCore.Mvc;
using VeyselAlanWebPage.Models;
using System.Linq;

namespace VeyselAlanWebPage.Controllers
{
    public class AuthController : Controller
    {
        private readonly Context _context;

        public AuthController(Context context)
        {
            _context = context;
        }

        // Giriş Sayfası
        public IActionResult Login()
        {
            return View(); // Buradaki "Login", /Views/Auth/Login.cshtml olmalı.
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.AdminUsers
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminUsername", admin.Username);
                return RedirectToAction("Index", "Admin"); // Giriş başarılı, Admin paneline yönlendirme
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }

        // Çıkış İşlemi
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminUsername");
            return RedirectToAction("Login");
        }
    }
}
