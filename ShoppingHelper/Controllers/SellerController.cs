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
    public class SellerController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        //
        // GET: /Seller/

        public ViewResult Index()
        {
            return View(db.Produse.ToList());
        }

        //
        // GET: /Seller/Details/5

        public ViewResult Details(int id)
        {
            Produs produs = db.Produse.Find(id);
            return View(produs);
        }

        //
        // GET: /Seller/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Seller/Create

        [HttpPost]
        public ActionResult Create(Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Produse.Add(produs);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(produs);
        }
        
        //
        // GET: /Seller/Edit/5
 
        public ActionResult Edit(int id)
        {
            Produs produs = db.Produse.Find(id);
            return View(produs);
        }

        //
        // POST: /Seller/Edit/5

        [HttpPost]
        public ActionResult Edit(Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produs);
        }

        //
        // GET: /Seller/Delete/5
 
        public ActionResult Delete(int id)
        {
            Produs produs = db.Produse.Find(id);
            return View(produs);
        }

        //
        // POST: /Seller/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Produs produs = db.Produse.Find(id);
            db.Produse.Remove(produs);
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