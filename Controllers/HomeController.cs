using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace NotDefteri.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Index(string kullanici, string sifre)
        {
            var kayitliSifre = HttpContext.Session.GetString("sifre") ?? "1234";

            if (kullanici == "admin" && sifre == kayitliSifre)
            {
                HttpContext.Session.SetString("kullanici", kullanici);
                return RedirectToAction("Index", "Note");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre yanlış!";
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }}