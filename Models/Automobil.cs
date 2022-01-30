using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoskola_Mia.Models
{
    public class Automobil
    {
        public int Id { get; set; }
        public string Registracija { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }

        //public ICollection<Autoskola> Autoskole { get; set; }
        //public ICollection<Tim> Timovi { get; set; }
    }
}
