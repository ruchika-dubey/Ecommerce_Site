using Ecommerce_Site.Data;
using Ecommerce_Site.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Ecommerce_Site.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }




        public IActionResult Index()
        {
            return View(_db.LaptopModel.ToList());
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //GET product detail acation method
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.LaptopModel.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        //GET product detail acation method
        [Authorize]
        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.LaptopModel.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        //POST product detail acation method
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddToCart(LaptopModel productTypes)
        {
            TempData["Orded"] = "Order Has Been Placed Sucessfully!";


            return RedirectToAction(nameof(Index));

        }




    }
}
