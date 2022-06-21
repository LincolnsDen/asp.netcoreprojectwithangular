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
    public class SeasonController : Controller
    {
        DbContextAng db = null;

        public SeasonController(DbContextAng dbContextAng)
        {
            db = dbContextAng;
        }
        public IActionResult Index()
        {
            return Json(db.seasons.ToList());
        }

        public IActionResult Details(int ID)
        {
            return Json(db.seasons.Find(ID));
        }

        public IActionResult Create([FromBody] Season seasons)
        {
            db.seasons.Add(seasons);
            db.SaveChanges();
            return Json("Created succesfully");
        }

        public IActionResult Edit([FromBody] Season seasons)
        {
            db.seasons.Attach(seasons);
            db.Entry(seasons).State = EntityState.Modified;
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
            var aa = db.seasons.Find(ID);
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
