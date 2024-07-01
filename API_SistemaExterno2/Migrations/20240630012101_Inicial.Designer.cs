﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using API_SistemaExterno2.Data;

#nullable disable

namespace API_SistemaExterno2.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20240630012101_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_SistemaExterno2.Models.Usuario", b =>
            {
                b.Property<int>("IdUsuario")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Telefone")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)");

                b.HasKey("IdUsuario");

                b.ToTable("Usuarios");
            });
#pragma warning restore 612, 618
        }
    }
}
