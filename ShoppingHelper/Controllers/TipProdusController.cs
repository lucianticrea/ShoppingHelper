using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingHelper;

namespace ShopHelper.Controllers
{ 
    public class TipProdusController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        //
        // GET: /TipProdus/

        public ViewResult Index()
        {
            return View(db.Produse.ToList());
        }

        //
        // GET: /TipProdus/Details/5

        public ViewResult Details(int id)
        {
            TipProdus tipprodus = db.TipProduse.Find(id);
            return View(tipprodus);
        }

        //
        // GET: /TipProdus/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipProdus/Create

        [HttpPost]
        public ActionResult Create(TipProdus tipprodus)
        {
            if (ModelState.IsValid)
            {
                db.TipProduse.Add(tipprodus);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipprodus);
        }
        
        //
        // GET: /TipProdus/Edit/5
 
        public ActionResult Edit(int id)
        {
            TipProdus tipprodus = db.TipProduse.Find(id);
            return View(tipprodus);
        }

        //
        // POST: /TipProdus/Edit/5

        [HttpPost]
        public ActionResult Edit(TipProdus tipprodus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipprodus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipprodus);
        }

        //
        // GET: /TipProdus/Delete/5
 
        public ActionResult Delete(int id)
        {
            TipProdus tipprodus = db.TipProduse.Find(id);
            return View(tipprodus);
        }

        //
        // POST: /TipProdus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipProdus tipprodus = db.TipProduse.Find(id);
            db.TipProduse.Remove(tipprodus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}