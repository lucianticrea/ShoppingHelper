using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ShoppingHelper
{
    public class ShopModelDatabaseInitializer : DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
       protected override void Seed(ShoppingContext context)
       {
           //GetCategories().ForEach(c => context.Categorii.Add(c));
           GetTipProduse().ForEach(p => context.TipProduse.Add(p));

           GetMagazine().ForEach(m => context.Magazine.Add(m));
           context.SaveChanges();
       }

       public static List<Magazin> GetMagazine()
       {
           return new List<Magazin>()
           {
               new Magazin
               {
                   Id = 1,
                   Nume = "Carrefour",
                   Produs = new List<Produs>
                   {}
               },
               new Magazin
               {
                   Id = 2,
                   Nume = "Auchan",
                   Produs = new List<Produs>
                   {}
                }
           };

       }

        /*
       private static List<Categorie> GetCategories()
       {
           return new List<Categorie>();
       }
        */

       public static List<TipProdus> GetTipProduse()
       {
           return new List<TipProdus>
                {
                    new TipProdus
                    {
                        Id = 1,
                        Denumire = "Ciocolata",
                        UnitateMasura = "buc",
                        Produs = new List<Produs>
                        {}
                    }
                };
       }
    }
}
