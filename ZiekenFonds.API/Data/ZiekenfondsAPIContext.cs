using ZiekenFonds.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Monitor = ZiekenFonds.API.Models.Monitor;

namespace ZiekenFonds.API.Data
{
    public class ZiekenFondsApiContext : IdentityDbContext<CustomUser>
    {

        public ZiekenFondsApiContext(DbContextOptions<ZiekenFondsApiContext> options) : base(options) { }

        public DbSet<Activiteit> Activiteiten { get; set; }
        public DbSet<Bestemming> Bestemmingen { get; set; }
        public DbSet<CustomUser> Personen { get; set; }
        public DbSet<Deelnemer> Deelnemers { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Groepsreis> Groepsreizen { get; set; }
        public DbSet<Kind> Kinderen { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Onkosten> Onkosten { get; set; }
        public DbSet<Opleiding> Opleidingen { get; set; }
        public DbSet<OpleidingPersoon> OpleidingPersonen { get; set; }
        public DbSet<Programma> Programmas { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Activiteit>().ToTable("Activiteit");
            modelBuilder.Entity<Bestemming>().ToTable("Bestemming");
            modelBuilder.Entity<CustomUser>().ToTable("Persoon");
            modelBuilder.Entity<Deelnemer>().ToTable("Deelnemer");
            modelBuilder.Entity<Foto>().ToTable("Foto");
            modelBuilder.Entity<Groepsreis>().ToTable("Groepsreis").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Kind>().ToTable("Kind");
            modelBuilder.Entity<Onkosten>().ToTable("Onkosten");
            modelBuilder.Entity<Opleiding>().ToTable("Opleiding");
            modelBuilder.Entity<OpleidingPersoon>().ToTable("Opleiding Persoon");
            modelBuilder.Entity<Programma>().ToTable("Programma");
            modelBuilder.Entity<Review>().ToTable("Review");

            //Ak Bestemmming
            modelBuilder.Entity<Bestemming>()
                .HasAlternateKey(p => p.Code);

            //Opleiding
            modelBuilder.Entity<Opleiding>()
                .HasOne(p => p.HoofdOpleiding)
                .WithMany(p => p.VereisteOpleidingen)
                .HasForeignKey(p => p.OpleidingVereist)
                .OnDelete(DeleteBehavior.Restrict);

            //Monitor en Groepsreis
            modelBuilder.Entity<Monitor>()
                .HasOne(p => p.Groepsreis)
                .WithMany(x => x.Monitors)
                .HasForeignKey(y => y.GroepsreisId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //CustomUser en Monitor 
            modelBuilder.Entity<Monitor>()
                .HasOne(p => p.Persoon)
                .WithMany(x => x.Monitors)
                .HasForeignKey(y => y.PersoonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Programma en Activiteit
            modelBuilder.Entity<Programma>()
                .HasOne(p => p.Activiteit)
                .WithMany(x => x.Programmas)
                .HasForeignKey(y => y.ActiviteitId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //Programma en Groepsreis
            modelBuilder.Entity<Programma>()
                .HasOne(p => p.Groepsreis)
                .WithMany(x => x.Programmas)
                .HasForeignKey(y => y.GroepsreisId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Programma
            modelBuilder.Entity<Programma>()
                .HasKey(x => new { x.ActiviteitId, x.GroepsreisId });

            //Ontkosten en Groepsreis
            modelBuilder.Entity<Onkosten>()
                .HasOne(p => p.Groepsreis)
                .WithMany(x => x.Onkosten)
                .HasForeignKey(y => y.GroepsreisId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Groepsreis en Bestemming 
            modelBuilder.Entity<Groepsreis>()
                .HasOne(p => p.Bestemming)
                .WithMany(x => x.Groepsreizen)
                .HasForeignKey(y => y.BestemmingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Reveiw en bestemming
            modelBuilder.Entity<Review>()
                .HasOne(p => p.Bestemming)
                .WithMany(x => x.Reviews)
                .HasForeignKey(y => y.BestemmingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Foto en bestemming
            modelBuilder.Entity<Foto>()
                .HasOne(p => p.Bestemming)
                .WithMany(x => x.Fotos)
                .HasForeignKey(y => y.BestemmingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Deelnemer en Groepsreis
            modelBuilder.Entity<Deelnemer>()
                .HasOne(p => p.Groepsreis)
                .WithMany(x => x.Deelnemers)
                .HasForeignKey(y => y.GroepsreisId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Deelnemer en kind
            modelBuilder.Entity<Deelnemer>()
                .HasOne(p => p.Kind)
                .WithMany(x => x.Deelnemers)
                .HasForeignKey(y => y.KindId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //CustomUser en kind
            modelBuilder.Entity<Kind>()
                .HasOne(p => p.Persoon)
                .WithMany(x => x.Kinderen)
                .HasForeignKey(y => y.PersoonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //CustomUser en review
            modelBuilder.Entity<Review>()
                .HasOne(p => p.Persoon)
                .WithMany(x => x.Reviews)
                .HasForeignKey(y => y.PersoonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //CustomUser en OpleidingPersoon
            modelBuilder.Entity<OpleidingPersoon>()
                .HasOne(p => p.Persoon)
                .WithMany(x => x.OpleidingenPersonen)
                .HasForeignKey(y => y.PersoonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Opleding en OpleidingPersoon
            modelBuilder.Entity<OpleidingPersoon>()
                .HasOne(p => p.Opleiding)
                .WithMany(x => x.OpleidingenPersonen)
                .HasForeignKey(y => y.OpleidingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();


        }
    }
}