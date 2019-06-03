using Microsoft.AspNetCore.Mvc;
using SamuraiCoreApp.Data;
using SamuraiCoreApp.Domain;
using System;
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
            //var samurai = new Samurai { Name = "Zoro" };
            //var battle = new Battle { Name = "Luffy vs Kaido" };
            //samuraiContext.AddRange(samurai, battle);
            //samuraiContext.SaveChanges();
            //var smr = samuraiContext.Samurais.Where(s => EF.Functions.Like(s.Name, "Z%")).ToList();
            //PrePopulateSamuraisAndBattles();
            return View();
        }

        private void PrePopulateSamuraisAndBattles()
        {
            samuraiContext.AddRange(
             new Samurai { Name = "Kikuchiyo" },
             new Samurai { Name = "Kambei Shimada" },
             new Samurai { Name = "Shichirōji " },
             new Samurai { Name = "Katsushirō Okamoto" },
             new Samurai { Name = "Heihachi Hayashida" },
             new Samurai { Name = "Kyūzō" },
             new Samurai { Name = "Gorōbei Katayama" }
           );

            samuraiContext.Battles.AddRange(
             new Battle { Name = "Battle of Okehazama", StartDate = new DateTime(1560, 05, 01), EndDate = new DateTime(1560, 06, 15) },
             new Battle { Name = "Battle of Shiroyama", StartDate = new DateTime(1877, 9, 24), EndDate = new DateTime(1877, 9, 24) },
             new Battle { Name = "Siege of Osaka", StartDate = new DateTime(1614, 1, 1), EndDate = new DateTime(1615, 12, 31) },
             new Battle { Name = "Boshin War", StartDate = new DateTime(1868, 1, 1), EndDate = new DateTime(1869, 1, 1) }
           );
            samuraiContext.SaveChanges();
        }

        public IActionResult Privacy()
        {
            var sbJoin = new SamuraiBattle { SamuraiId = 1, BattleId = 3 };
            samuraiContext.Add(sbJoin);
            samuraiContext.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
