using Ecommerce_Site.Data;
using Ecommerce_Site.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LaptopController : Controller
    {
        private  ApplicationDbContext _db;
        public LaptopController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            var data = _db.LaptopModel.ToList();
            return View(data);
        }
        //Create  Get Action Method
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        //Create  Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(LaptopModel laptopModel)
        {
            if(ModelState.IsValid)
            {
                _db.LaptopModel.Add(laptopModel);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(laptopModel);
        }
        //GET Edit Action Method
        [Authorize]
        public ActionResult Edit(int? id)
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

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(LaptopModel productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product type has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
        //GET Details Action Method
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

        //POST Details Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(LaptopModel productTypes)
        {
            return RedirectToAction(nameof(Index));

        }
        //GET Delete Action Method
        [Authorize]
        public ActionResult Delete(int? id)
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

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Delete(int? id, LaptopModel productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != productTypes.ID)
            {
                return NotFound();
            }

            var productType = _db.LaptopModel.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product type has been deleted";

                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }





    }
}
