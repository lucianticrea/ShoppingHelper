using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.DAL
{
    public class Categorie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Nume { get; set; }
    }
}
