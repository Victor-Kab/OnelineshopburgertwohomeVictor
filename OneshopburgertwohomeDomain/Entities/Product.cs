using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneshopburgertwohomeDomain.Entities
{
   public class Product
    {
        [Key]
        public int Idproduit { get; set; }
        public string Libelle  { get; set; }
        public  decimal Prix { get; set; }
        public int Qstock { get; set; }
        public string Category  { get; set; }
        public string Description { get; set; }
    }
}
