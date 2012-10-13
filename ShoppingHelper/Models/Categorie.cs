using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper
{
    public class Categorie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(1000), Display(Name = "Categorie")]
        public string Nume { get; set; }
    }
}
