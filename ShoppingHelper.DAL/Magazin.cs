using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.DAL
{
    public class Magazin
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Nume { get; set; }

        public virtual ICollection<MagazinProdus> MagazinProdus { get; set; }

    }
}
