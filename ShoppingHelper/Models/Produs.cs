using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingHelper
{
    public class Produs
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Magazin")]
        public int IdMagazin { get; set; }

        [Display(Name = "Tip Produs")]
        public int IdTipProdus { get; set; }

        [Required, Display(Name = "Pret")]
        public decimal Pret { get; set; }

        [ForeignKey("IdMagazin")]
        public virtual Magazin Magazin { get; set; }

        [ForeignKey("IdTipProdus")]
        public virtual TipProdus TipProdus { get; set; }
    }
}
