using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Autoskola_Mia.Models
{
    public class Zaposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public string Email { get; set; }
        public int Placa { get; set; }
        public string Pozicija { get; set; }

        //public ICollection<Tim> Timovi { get; set; }
        //public ICollection<Autoskola> Autoskole { get; set; }
        //public string[] Spolovi => new string[] { "M", "Ž" };
        //public string[] Pozicije => new string[] { "Predavač", "Instruktor", "Instruktorica" };
    }
}
