using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoskola_Mia.Models
{
    public class Autoskola
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }

        //public ICollection<Tim> Timovi { get; set; }
        
    }
}
