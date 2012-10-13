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

        [Required, StringLength(1000), Display(Name = "Denumire Produs")]
        public string Denumire { get; set; }

        [Display(Name = "Unitate de Masura")]
        public string UnitateMasura { get; set; }

        public virtual ICollection<MagazinProdus> MagazinProdus { get; set; }



    }
}
