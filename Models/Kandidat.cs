using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoskola_Mia.Models
{
    public class Kandidat
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public string Email { get; set; }

        //public ICollection<Tim> Timovi { get; set; }
        //public ICollection<Autoskola> Autoskole { get; set; }
        //public string[] Spolovi => new string[] { "M", "Ž" };
    }
}
