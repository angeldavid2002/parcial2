﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(Parcial2Context))]
    partial class Parcial2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Infraccion", b =>
                {
                    b.Property<int>("idInfraccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaInfraccion")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPersona")
                        .HasColumnType("int");

                    b.Property<int?>("personaidentificacion")
                        .HasColumnType("int");

                    b.Property<decimal>("valorMulta")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idInfraccion");

                    b.HasIndex("personaidentificacion");

                    b.ToTable("Infracciones");
                });

            modelBuilder.Entity("Entidad.Liquidacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ValoraPagar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("fechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("idInfraccion")
                        .HasColumnType("int");

                    b.Property<int?>("infraccionidInfraccion")
                        .HasColumnType("int");

                    b.Property<decimal>("valorMulta")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("infraccionidInfraccion");

                    b.ToTable("Liquidaciones");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<int>("identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("identificacion");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidad.Infraccion", b =>
                {
                    b.HasOne("Entidad.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("personaidentificacion");

                    b.Navigation("persona");
                });

            modelBuilder.Entity("Entidad.Liquidacion", b =>
                {
                    b.HasOne("Entidad.Infraccion", "infraccion")
                        .WithMany()
                        .HasForeignKey("infraccionidInfraccion");

                    b.Navigation("infraccion");
                });
#pragma warning restore 612, 618
        }
    }
}
