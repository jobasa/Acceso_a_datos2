﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_AcessoADatos.Models;

namespace Proyecto_AcessoADatos.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    partial class PlaceMyBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.Apuestas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cuota");

                    b.Property<float>("Dinero_apostado");

                    b.Property<int>("ID_MERCADO");

                    b.Property<int>("ID_USUARIOS");

                    b.Property<string>("Tipo_apuesta");

                    b.Property<int?>("mercadoid");

                    b.HasKey("Id");

                    b.HasIndex("mercadoid");

                    b.ToTable("Apuestas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cuota = 3m,
                            Dinero_apostado = 100f,
                            ID_MERCADO = 1,
                            ID_USUARIOS = 1,
                            Tipo_apuesta = "Aouesta Over"
                        });
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Equipo_Local");

                    b.Property<string>("Equipo_visitante");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            EventoId = 1,
                            Equipo_Local = "Valencia",
                            Equipo_visitante = "Ajax"
                        });
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.Mercado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cuota_over");

                    b.Property<decimal>("Cuota_under");

                    b.Property<float>("Dinero_over");

                    b.Property<float>("Dinero_under");

                    b.Property<int?>("EventoId");

                    b.Property<int>("IDEvento");

                    b.Property<string>("tipo_mercado");

                    b.HasKey("id");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercados");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Cuota_over = 2m,
                            Cuota_under = 2m,
                            Dinero_over = 3f,
                            Dinero_under = 3f,
                            IDEvento = 1,
                            tipo_mercado = "LaLiga"
                        });
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido");

                    b.Property<int>("Edad");

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Apellido = "Banyuls",
                            Edad = 20,
                            Email = "jobanyuls@gmail.com",
                            Nombre = "Joan"
                        });
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.cuenta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre_banco");

                    b.Property<string>("Num_tarjeta_vinculada");

                    b.Property<decimal>("Saldo_actual");

                    b.Property<int>("UsuarioId");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nombre_banco = "La Caixa",
                            Num_tarjeta_vinculada = "4000001234567899",
                            Saldo_actual = 100m,
                            UsuarioId = 1
                        });
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.Apuestas", b =>
                {
                    b.HasOne("Proyecto_AcessoADatos.Models.Mercado", "mercado")
                        .WithMany("Apuestas")
                        .HasForeignKey("mercadoid");
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.Mercado", b =>
                {
                    b.HasOne("Proyecto_AcessoADatos.Models.Evento", "evento")
                        .WithMany("Mercados")
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("Proyecto_AcessoADatos.Models.cuenta", b =>
                {
                    b.HasOne("Proyecto_AcessoADatos.Models.Usuario", "Usuario")
                        .WithOne("cuenta")
                        .HasForeignKey("Proyecto_AcessoADatos.Models.cuenta", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}