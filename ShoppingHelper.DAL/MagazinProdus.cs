using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.DAL
{
    public class MagazinProdus
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int IdMagazin { get; set; }

        public int IdProdus { get; set; }

        public virtual Magazin Magazin { get; set; }

        public virtual Produs Produs { get; set; }
    }
}
