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
    public class SuplierController : Controller
    {
        DbContextAng db = null;

        public SuplierController(DbContextAng dbContextAng)
        {
            db = dbContextAng;
        }
        public IActionResult Index()
        {
            return Json(db.fruitSuppliers.ToList());
        }

       
        public IActionResult Details(int ID)
        {
            return Json(db.fruitSuppliers.Find(ID));
        }

        
        public IActionResult Create([FromBody] FruitSupplier fruitSuppliers)
        {
            db.fruitSuppliers.Add(fruitSuppliers);
            db.SaveChanges();
            return Json("Created succesfully");
        }

        
        

        
        public IActionResult Edit([FromBody] FruitSupplier fruitSuppliers)
        {
            db.fruitSuppliers.Attach(fruitSuppliers);
            db.Entry(fruitSuppliers).State = EntityState.Modified;
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
            var aa = db.fruitSuppliers.Find(ID);
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
