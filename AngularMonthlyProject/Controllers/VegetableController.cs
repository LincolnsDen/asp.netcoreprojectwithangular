using AngularMonthlyProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMonthlyProject.Controllers
{
    public class VegetableController : Controller
    {
        DbContextAng db = null;

        public VegetableController(DbContextAng dbContextAng)
        {
            db = dbContextAng;
        }
        public IActionResult Index()
        {
            return Json(db.vegetables.ToList());
        }

        public IActionResult Details(int ID)
        {
            return Json(db.vegetables.Find(ID));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vegetable vegetables)
        {
            db.vegetables.Add(vegetables);
            db.SaveChanges();
            return Json("Created succesfully");
        }



        public IActionResult Edit([FromBody] Vegetable vegetables)
        {
            db.vegetables.Attach(vegetables);
            db.Entry(vegetables).State = EntityState.Modified;
            db.SaveChanges();
            return Json("Edited Successfully");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int ID, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json("OK");
            }
        }


        public IActionResult Delete(int ID)
        {
            var aa = db.vegetables.Find(ID);
            db.Entry(aa).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("deleted Successfully");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int ID, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json("OK");
            }
        }
    }
}
