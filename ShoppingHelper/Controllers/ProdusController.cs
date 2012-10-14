using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingHelper;

namespace ShoppingHelper.Controllers
{
    [Authorize]
    public class ProdusController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        //
        // GET: /Produs/

        public ViewResult Index()
        {
           // Session["IdMagazin"] = 2;
        
            return View(db.Produse.ToList());
        }

        //
        // GET: /Produs/Details/5

        public ViewResult Details(int id)
        {
            Produs produs = db.Produse.Find(id);
            return View(produs);
        }

        //
        // GET: /Produs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Produs/Create

        [HttpPost]
        public ActionResult Create(Produs produs)
        {
            if (ModelState.IsValid)
            {
                int idMagazin = GetIdMagazin();
                produs.IdMagazin = idMagazin;
                produs.Magazin = db.Magazine.FirstOrDefault(m => m.Id == idMagazin);

                db.Produse.Add(produs);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(produs);
        }

        private int GetIdMagazin()
        {
            object objIdMagazin = Session["IdMagazin"];
            if (objIdMagazin == null)
            {
                throw new Exception("Nu s-a gasit nici un id pentru magazin");
            }

            int idMagazin = -1;
            if (!int.TryParse(objIdMagazin.ToString(), out idMagazin))
            {
                throw new Exception("Nu s-a gasit un id valid pentru magazin ");
            }
            return idMagazin;
        }
        
        //
        // GET: /Produs/Edit/5
 
        public ActionResult Edit(int id)
        {
            Produs produs = db.Produse.Find(id);
            return View(produs);
        }

        //
        // POST: /Produs/Edit/5

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
        // GET: /Produs/Delete/5
 
        public ActionResult Delete(int id)
        {
            Produs produs = db.Produse.Find(id);
            return View(produs);
        }

        //
        // POST: /Produs/Delete/5

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