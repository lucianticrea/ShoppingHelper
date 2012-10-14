using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopHelper;
using ShoppingHelper;

namespace ShopHelper.Controllers
{ 
    public class ShoppingListPerStoreController : Controller
    {
        private ShoppingContext db = new ShoppingContext();
        private List<Produs> produseList;
        private List<TipProdus> tipProdusList;
        public List<ShoppingListPerStore> shoppingList=new List<ShoppingListPerStore>();
        private ShoppingListPerStore shop = new ShoppingListPerStore();
        private List<Magazin> magazine;

        //
        // GET: /ShoppingListPerStore/

        public ViewResult Index()
        {
            tipProdusList=(List<TipProdus>)Session["ShoppingList"];
          //  tipProdusList = db.TipProduse.ToList();
            produseList = db.Produse.ToList();
           //s tipProdusList = db.TipProduse.Where(p => p.Id == 1).ToList();
            magazine = db.Magazine.ToList();
            
            var listeMagazine = tipProdusList.Select(tp => tp.Produs.Select(p => p.Magazin)).ToList();
            foreach (var listaMagazine in listeMagazine)
            {
                magazine=magazine.Intersect(listaMagazine).ToList();
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
            


            return View("Index",shoppingList);
        }

        private void RefreshShoppingList()
        {
            shop = new ShoppingListPerStore();
            shop.Produse = produseList;
            shop.TipProdus = tipProdusList;
            
        }

      
    }
}