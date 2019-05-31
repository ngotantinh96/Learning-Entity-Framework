using Microsoft.AspNetCore.Mvc;
using SamuraiCoreApp.Data;
using SamuraiCoreApp.Domain;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SamuraiContext samuraiContext;

        public HomeController(SamuraiContext samuraiContext)
        {
            this.samuraiContext = samuraiContext;
        }
        public IActionResult Index()
        {
            var samurai = new Samurai { Name = "Zoro" };
            var battle = new Battle { Name = "Luffy vs Kaido" };
            samuraiContext.AddRange(samurai, battle);
            samuraiContext.SaveChanges();
            return View();
        }

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
