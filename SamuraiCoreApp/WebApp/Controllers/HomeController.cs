using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiCoreApp.Data;
using System.Diagnostics;
using System.Linq;
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
            //var samurai = new Samurai { Name = "Zoro" };
            //var battle = new Battle { Name = "Luffy vs Kaido" };
            //samuraiContext.AddRange(samurai, battle);
            //samuraiContext.SaveChanges();
            var smr = samuraiContext.Samurais.Where(s => EF.Functions.Like(s.Name, "Z%")).ToList();
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
