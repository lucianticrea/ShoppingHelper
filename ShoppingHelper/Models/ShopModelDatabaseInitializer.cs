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
           //GetProduse().ForEach(p => context.Produse.Add(p));

           //context.SaveChanges();
       }
        /*
       private static List<Categorie> GetCategories()
       {
           return new List<Categorie>();
       }

       private static List<Produs> GetProduse()
       {
           return new List<Produs>();
       }*/
    }
}
