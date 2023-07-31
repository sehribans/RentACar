using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RentACar.Models;


namespace RentACar.Controllers
{
    public class GirisController : Controller
    {
        DataContex _c;

        public GirisController(DataContex c)
        {
            _c = c;
        }

        [HttpGet]
        public IActionResult Index(bool? durum)
        {
            if (durum != null)
            {
                ViewBag.Durum = "E-Posta veya Parola Hatalıdır!";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string mail, string password)
        {
            var user = _c.TBL_KULLANICI.FirstOrDefault(m => m.EPOSTA == mail && m.PAROLA == password);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("KullaniciAdi", user.AD ?? string.Empty));
                claims.Add(new Claim("email", user.EPOSTA));
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Index), new { durum = false });
            }
        }

        public IActionResult LogOut()
        {
          
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Kayit()
        {

            return View();
        }

        [HttpPost]
        public IActionResult KayitYap(TBL_KULLANICI model)
        {
            var ekle= _c.TBL_KULLANICI.Add(model);
            _c.SaveChanges();
            return RedirectToAction("Kayit");
        }
    }
}
