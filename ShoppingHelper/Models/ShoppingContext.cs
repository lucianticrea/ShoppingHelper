using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ShoppingHelper
{
    public class ShoppingContext : DbContext
    {

        public ShoppingContext() : base("ShoppingHelper")
        {
        }

        public DbSet<Produs> Produse { get; set; }
        public DbSet<Magazin> Magazine { get; set; }
        public DbSet<MagazinProdus> MagazinProduse { get; set; }
        public DbSet<Categorie> Categorii { get; set; }
    }
}
