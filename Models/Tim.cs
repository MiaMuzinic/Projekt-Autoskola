using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoskola_Mia.Models
{
    public class Tim
    {
        public int Id { get; set; }
        public int Automobil_Id { get; set; }
        public int Autoskola_Id { get; set; }
        public int Kandidat_Id { get; set; }
        public int Zaposlenik_Id { get; set; }

        public Automobil Automobil { get; set; }
        public Autoskola Autoskola { get; set; }
        public Kandidat Kandidat { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

    }
}
