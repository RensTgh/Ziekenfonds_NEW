﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZiekenFonds.API.Data;

#nullable disable

namespace ZiekenFonds.API.Migrations
{
    [DbContext(typeof(ZiekenFondsApiContext))]
    [Migration("20241217142303_dbcontextUpdates")]
    partial class dbcontextUpdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Activiteit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Activiteit", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Bestemming", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaxLeeftijd")
                        .HasColumnType("int");

                    b.Property<int>("MinLeeftijd")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.ToTable("Bestemming", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.CustomUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gemeente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Huisdokter")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Huisnummer")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<bool>("IsActief")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("RekeningNummer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefoonNummer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isHoofdMonitor")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Persoon", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Deelnemer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroepsreisId")
                        .HasColumnType("int");

                    b.Property<int>("KindId")
                        .HasColumnType("int");

                    b.Property<string>("Opmerking")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroepsreisId");

                    b.HasIndex("KindId");

                    b.ToTable("Deelnemer", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BestemmingId");

                    b.ToTable("Foto", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Groepsreis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Begindatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Einddatum")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BestemmingId");

                    b.ToTable("Groepsreis", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Kind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Allergieën")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Medicatie")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersoonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PersoonId");

                    b.ToTable("Kind", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Monitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroepsreisId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHoofdMonitor")
                        .HasColumnType("bit");

                    b.Property<string>("PersoonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GroepsreisId");

                    b.HasIndex("PersoonId");

                    b.ToTable("Monitors");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Onkosten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Bedrag")
                        .HasColumnType("real");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroepsreisId")
                        .HasColumnType("int");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GroepsreisId");

                    b.ToTable("Onkosten", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Opleiding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AantalPlaatsen")
                        .HasColumnType("int");

                    b.Property<DateTime>("Begindatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Einddatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OpleidingVereist")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OpleidingVereist");

                    b.ToTable("Opleiding", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.OpleidingPersoon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OpleidingId")
                        .HasColumnType("int");

                    b.Property<string>("PersoonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OpleidingId");

                    b.HasIndex("PersoonId");

                    b.ToTable("Opleiding Persoon", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Programma", b =>
                {
                    b.Property<int>("ActiviteitId")
                        .HasColumnType("int");

                    b.Property<int>("GroepsreisId")
                        .HasColumnType("int");

                    b.HasKey("ActiviteitId", "GroepsreisId");

                    b.HasIndex("GroepsreisId");

                    b.ToTable("Programma", (string)null);
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<string>("PersoonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BestemmingId");

                    b.HasIndex("PersoonId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZiekenFonds.API.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Deelnemer", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Groepsreis", "Groepsreis")
                        .WithMany("Deelnemers")
                        .HasForeignKey("GroepsreisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ZiekenFonds.API.Models.Kind", "Kind")
                        .WithMany("Deelnemers")
                        .HasForeignKey("KindId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Groepsreis");

                    b.Navigation("Kind");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Foto", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Bestemming", "Bestemming")
                        .WithMany("Fotos")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bestemming");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Groepsreis", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Bestemming", "Bestemming")
                        .WithMany("Groepsreizen")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bestemming");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Kind", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.CustomUser", "Persoon")
                        .WithMany("Kinderen")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Persoon");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Monitor", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Groepsreis", "Groepsreis")
                        .WithMany("Monitors")
                        .HasForeignKey("GroepsreisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ZiekenFonds.API.Models.CustomUser", "Persoon")
                        .WithMany("Monitors")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Groepsreis");

                    b.Navigation("Persoon");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Onkosten", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Groepsreis", "Groepsreis")
                        .WithMany("Onkosten")
                        .HasForeignKey("GroepsreisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Groepsreis");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Opleiding", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Opleiding", "HoofdOpleiding")
                        .WithMany("VereisteOpleidingen")
                        .HasForeignKey("OpleidingVereist")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("HoofdOpleiding");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.OpleidingPersoon", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Opleiding", "Opleiding")
                        .WithMany("OpleidingenPersonen")
                        .HasForeignKey("OpleidingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZiekenFonds.API.Models.CustomUser", "Persoon")
                        .WithMany("OpleidingenPersonen")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Opleiding");

                    b.Navigation("Persoon");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Programma", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Activiteit", "Activiteit")
                        .WithMany("Programmas")
                        .HasForeignKey("ActiviteitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ZiekenFonds.API.Models.Groepsreis", "Groepsreis")
                        .WithMany("Programmas")
                        .HasForeignKey("GroepsreisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Activiteit");

                    b.Navigation("Groepsreis");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Review", b =>
                {
                    b.HasOne("ZiekenFonds.API.Models.Bestemming", "Bestemming")
                        .WithMany("Reviews")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ZiekenFonds.API.Models.CustomUser", "Persoon")
                        .WithMany("Reviews")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bestemming");

                    b.Navigation("Persoon");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Activiteit", b =>
                {
                    b.Navigation("Programmas");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Bestemming", b =>
                {
                    b.Navigation("Fotos");

                    b.Navigation("Groepsreizen");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.CustomUser", b =>
                {
                    b.Navigation("Kinderen");

                    b.Navigation("Monitors");

                    b.Navigation("OpleidingenPersonen");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Groepsreis", b =>
                {
                    b.Navigation("Deelnemers");

                    b.Navigation("Monitors");

                    b.Navigation("Onkosten");

                    b.Navigation("Programmas");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Kind", b =>
                {
                    b.Navigation("Deelnemers");
                });

            modelBuilder.Entity("ZiekenFonds.API.Models.Opleiding", b =>
                {
                    b.Navigation("OpleidingenPersonen");

                    b.Navigation("VereisteOpleidingen");
                });
#pragma warning restore 612, 618
        }
    }
}