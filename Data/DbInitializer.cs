using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoskola_Mia.Models;

namespace Autoskola_Mia.Data
{
    public class DbInitializer
    {
        public static void Initialize(AutoskolaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Autoskole.Any())
            {
                return;
            }
            var autoskole = new Autoskola[]
            {
                new Autoskola{Naziv="Telefax",Adresa="Papndopulova ul. 15",Email="info@telefax.hr"},
                new Autoskola{Naziv="Marušić",Adresa="Benkovaćka ul. 10a",Email="dental.marusic@dentalcentarmarusic.com"},
                new Autoskola{Naziv="Golf",Adresa="Ul. Domovinskog rata 3",Email="info@autoskolagolf.hr"},
                new Autoskola{Naziv="Hajduk",Adresa="Bihačka 2a",Email="auto-skola-hajduk@st.t-com.hr"},
            };
            foreach (Autoskola a in autoskole)
            {
                context.Autoskole.Add(a);
            }
            context.SaveChanges();

            var zaposlenici = new Zaposlenik[]
            {

                new Zaposlenik {
                    Id= 0,
                    Ime= "Ante",
                    Prezime= "Anić",
                    Spol= "M",
                    Email= "aanic@gmail.com",
                    Placa=  6500,
                    Pozicija="Predavač" },

                new Zaposlenik {
                    Id= 1,
                    Ime= "Katija",
                    Prezime= "Leko",
                    Spol= "ž",
                    Email= "kleko@gmail.com",
                    Placa=  7000,
                    Pozicija="Instruktorica" },

                new Zaposlenik {
                    Id= 2,
                    Ime= "Josko",
                    Prezime= "Bubalo",
                    Spol= "M",
                    Email= "jbubalo@gmail.com",
                    Placa=  7500,
                    Pozicija="Instruktor" },

                new Zaposlenik {
                    Id= 3,
                    Ime= "Mate",
                    Prezime= "Matić",
                    Spol= "M",
                    Email= "mmatic@gmail.com",
                    Placa=  7000,
                    Pozicija="Instruktor" },
            };
            foreach (Zaposlenik z in zaposlenici)
            {
                context.Zaposlenici.Add(z);
            }
            context.SaveChanges();

            var kandidati = new Kandidat[]
            {

                new Kandidat {
                    Ime= "Antonela",
                    Prezime= "Markic",
                    Spol= "Ž",
                    Email= "amarkic@gmail.com" },

                new Kandidat {
                    Ime= "Laura",
                    Prezime= "Milvic",
                    Spol= "Ž",
                    Email= "lmilvic@gmail.com" },

                new Kandidat {
                    Ime= "Ana",
                    Prezime= "Skelic",
                    Spol= "Ž",
                    Email= "askelic@gmail.com" },

                new Kandidat {
                    Ime= "Darko",
                    Prezime= "Knezovic",
                    Spol= "M",
                    Email= "dknezovic@gmail.com" },
            };
            foreach (Kandidat k in kandidati)
            {
                context.Kandidati.Add(k);
            }
            context.SaveChanges();

            var automobili = new Automobil[]
            {
            new Automobil{Registracija="ST-5778-A",Model="Golf 7",Marka="Volkswagen"},
            new Automobil{Registracija="ST-432-AM",Model="Golf 7",Marka="Volkswagen"},
            new Automobil{Registracija="ST-891-MP",Model="Clio",Marka="Renault"},
            new Automobil{Registracija="ST-0001-M",Model="Fiat 500",Marka="Fiat"},
            };

            foreach (Automobil auto in automobili)
            {
                context.Automobili.Add(auto);
            }
            context.SaveChanges();


            
            var timovi = new Tim[]
            {
            new Tim{Autoskola_Id=0,Zaposlenik_Id=1,Kandidat_Id=0,Automobil_Id=0},
            new Tim{Autoskola_Id=0,Zaposlenik_Id=2,Kandidat_Id=2,Automobil_Id=0},
            new Tim{Autoskola_Id=1,Zaposlenik_Id=3,Kandidat_Id=1,Automobil_Id=2},
            };
            foreach (Tim t in timovi)
            {
                context.Timovi.Add(t);
            }
            context.SaveChanges();
        }
    }
}
