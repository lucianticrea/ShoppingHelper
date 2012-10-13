using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper
{
    public class Produs
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id {get; set;}

        [Required, StringLength(1000), Display()]
        public string Denumire { get; set; }

        public decimal Pret { get; set; }

        public string UnitateMasura { get; set; }

        public virtual ICollection<MagazinProdus> MagazinProdus { get; set; }



    }
}
