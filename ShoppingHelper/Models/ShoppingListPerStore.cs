using ShoppingHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopHelper
{

    public class ShoppingListPerStore
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public List<Produs> Produse { get; set; }
        public List<TipProdus> TipProdus { get; set; }
        public decimal PretTotal { get; set;}
        public int MagazinId { get; set; }
    }
}