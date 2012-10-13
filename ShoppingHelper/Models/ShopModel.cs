using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ShoppingHelper
{
    public class ShopModelDatabaseInitializer : DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
       protected void Seed(ShoppingContext context)
       {
           GetCategorie().ForEach(c => context.Categorii.Add(c));
           GetProdus().ForEach(p => context.Produse.Add(p));
       }

       private static List<Categorie> GetCategorie()
       {
           return new List<Categorie>();
       }

       private static List<Produs> GetProdus()
       {
           return new List<Produs>();
       }
    }
}
