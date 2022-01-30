using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoskola_Mia.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoskola_Mia.Data
{
    public class AutoskolaContext : DbContext
    {
        public AutoskolaContext(DbContextOptions<AutoskolaContext> options) : base(options)
        {
        }

        public DbSet<Autoskola> Autoskole { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<Kandidat> Kandidati { get; set; }
        public DbSet<Tim> Timovi { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autoskola>().ToTable("Autoskola");
            modelBuilder.Entity<Zaposlenik>().ToTable("Zaposlenik");
            modelBuilder.Entity<Automobil>().ToTable("Automobil");
            modelBuilder.Entity<Kandidat>().ToTable("Kandidat");
            modelBuilder.Entity<Tim>().ToTable("Tim");

        }
    }
}

