using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingHelper;
using ShoppingHelper;
using System.Data.Entity.Infrastructure;

namespace ShoppingHelper.Controllers
{ 
    public class ShoppingListPerStoreController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        private List<Produs> produseList;
        private List<TipProdus> tipProdusList;
        public List<ShoppingListPerStore> shoppingList=new List<ShoppingListPerStore>();
        private ShoppingListPerStore shop = new ShoppingListPerStore();
        private List<Magazin> magazine;

        public ViewResult NoData()
        {
            return View();
        }
        //
        // GET: /ShoppingListPerStore/

        public ViewResult Index()
        {
            tipProdusList = Session["ShoppingList"] as List<TipProdus>;

            if (tipProdusList == null)
            {
                throw new Exception("Nu este Lista de cumparaturi in Sesiune!");
            }
          //  tipProdusList = db.TipProduse.ToList();
            produseList = db.Produse.ToList();
           //s tipProdusList = db.TipProduse.Where(p => p.Id == 1).ToList();
            magazine = db.Magazine.ToList();

            foreach (var tipProdus in tipProdusList)
            {
                var produse = produseList.Where(p => p.IdTipProdus == tipProdus.Id);
                var listaMagazinePerProdus = produse.Select(p => p.Magazin).ToList();
                magazine = magazine.Intersect(listaMagazinePerProdus).ToList();
            }

            foreach (Magazin magazin in magazine)
            {
                shop.PretTotal = (from x in produseList
                                  where x.IdMagazin == magazin.Id
                                  select x.Pret).Sum();
                shop.MagazinId = magazin.Id;
                shop.Produse = produseList;
                shop.TipProdus = tipProdusList;
                shoppingList.Add(shop);
                RefreshShoppingList();
            }


            if (shoppingList.Count() == 0)
            {
                return View("NoData");
            }

            return View("Index", shoppingList);
        }

        private void RefreshShoppingList()
        {
            shop = new ShoppingListPerStore();
            shop.Produse = produseList;
            shop.TipProdus = tipProdusList;
            
        }

      
    }
}