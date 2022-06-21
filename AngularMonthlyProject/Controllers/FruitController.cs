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
    public class FruitController : Controller
    {
        DbContextAng db = null;
        public FruitController(DbContextAng dbContextAng)
        {
            db = dbContextAng;
        }
        public IActionResult Index()
        {
           
            return Json(db.fruits.ToList());
        }

        // GET: FruitController/Details/5
        public IActionResult Details(int ID)
        {

            return Json(db.fruits.Find(ID));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Fruit fruit )
        {
            db.fruits.Add(fruit);
            db.SaveChanges();
            return Json("Created succesfully");
        }

        

       
        public IActionResult Edit([FromBody] Fruit fruit)
        {
            db.fruits.Attach(fruit);
            db.Entry(fruit).State = EntityState.Modified;
            db.SaveChanges();
            return Json("Edited Successfully");
        } 

        [HttpDelete]
      
        public IActionResult Delete(int ID)
        {
            var aa = db.fruits.Find(ID);
            db.Entry(aa).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("deleted Successfully");
        }

        
       
    }
}
