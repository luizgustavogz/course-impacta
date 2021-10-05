﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoMercadoFinal.Models;

namespace ProjetoMercadoFinal.Migrations
{
    [DbContext(typeof(ProjetoMercadoFinalDBContext))]
    partial class ProjetoMercadoFinalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Produto")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nm_Produto");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_Validade");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Vlr_Produto");

                    b.HasKey("Id");

                    b.ToTable("tblProduto");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Usuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("CD_Email");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("NM_Usuario");

                    b.Property<string>("Perfil")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("CD_Perfil_");

                    b.Property<string>("Senha")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("CD_Senha");

                    b.HasKey("Id");

                    b.ToTable("TblUsuario");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Venda")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id_Usuario");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Vlr_Total");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("tblVenda");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.VendaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Venda_Item")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int")
                        .HasColumnName("Id_Produto");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int")
                        .HasColumnName("Id_Venda");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Qtd_Item");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdVenda");

                    b.ToTable("TblVenda_Item");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.Venda", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.VendaItem", b =>
                {
                    b.HasOne("ProjetoMercadoFinal.Models.Produto", "Produto")
                        .WithMany("VendasDoProduto")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjetoMercadoFinal.Models.Venda", "Venda")
                        .WithMany("Itens")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.Produto", b =>
                {
                    b.Navigation("VendasDoProduto");
                });

            modelBuilder.Entity("ProjetoMercadoFinal.Models.Venda", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}