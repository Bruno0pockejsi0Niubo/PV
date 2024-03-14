using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DATABAZEK
{
    public class MojeDatabaze : DbContext
    {
        public DbSet<Zakaznik> Zakaznici { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Objednavka> Objednavky { get; set; }
        public DbSet<Dodavatel> Dodavatele { get; set; }
        public DbSet<PolozkaObjednavky> PolozkyObjednavek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa"; // Přihlašovací jméno
            consStringBuilder.Password = "student"; // Heslo
            consStringBuilder.InitialCatalog = "***"; // Název databáze
            consStringBuilder.DataSource = "***"; // IP adresa SQL Serveru a port (pokud je odlišný od výchozího)
            consStringBuilder.ConnectTimeout = 30;
            consStringBuilder.TrustServerCertificate = true;

            optionsBuilder.UseSqlServer(consStringBuilder.ConnectionString);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolozkaObjednavky>()
                .HasKey(oi => new { oi.ObjednavkaId, oi.ProduktId });

            modelBuilder.Entity<PolozkaObjednavky>()
                .HasOne(oi => oi.Objednavka)
                .WithMany(o => o.PolozkyObjednavky)
                .HasForeignKey(oi => oi.ObjednavkaId);

            modelBuilder.Entity<PolozkaObjednavky>()
                .HasOne(oi => oi.Produkt)
                .WithMany(p => p.PolozkyObjednavky)
                .HasForeignKey(oi => oi.ProduktId);
        }
    }
}
