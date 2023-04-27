using Microsoft.AspNetCore.Mvc;
using CarShop.Models;
using System.Diagnostics;


namespace MVC.Controllers
{
    public class HomeController : Controller
    {
            CarContext db;
            public HomeController(CarContext context)
            {
                db = context;
            }
            public IActionResult Index()
            {
                return View(db.Cars.ToList());
            }
            [HttpGet]
            public IActionResult Buy(int? id)
            {
                if (id == null) return RedirectToAction("Index");
                ViewBag.CarId = id;
                return View();
            }
             public IActionResult Privacy() { return View(); }

             public IActionResult About(int? id) 
             {
                if (id == null) return RedirectToAction("Index");
                ViewBag.CarId = id;
                return View(); 
             }

            [HttpPost]
           public string Buy(Order order)
            {
                db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
                return "Спасибо, " + order.User + ", за покупку!";
            }
    }
}