using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ShopHelper;

namespace ShoppingHelper
{
    public class ShoppingContext : DbContext
    {

        public ShoppingContext() : base("ShoppingHelper")
        {
        }

        public void OnContextCreated()
        {
             this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<TipProdus> TipProduse { get; set; }
        public DbSet<Magazin> Magazine { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Categorie> Categorii { get; set; }

        public DbSet<ShoppingListPerStore> ShoppingListPerStores { get; set; }
    }
}
