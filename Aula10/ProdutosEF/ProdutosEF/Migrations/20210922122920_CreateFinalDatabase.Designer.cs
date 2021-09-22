﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdutosEF.Repositories;

namespace ProdutosEF.Migrations
{
    [DbContext(typeof(ProdutosEFDBContext))]
    [Migration("20210922122920_CreateFinalDatabase")]
    partial class CreateFinalDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProdutosEF.Models.Produto", b =>
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
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Vlr_Produto");

                    b.HasKey("Id");

                    b.ToTable("tblProduto");
                });

            modelBuilder.Entity("ProdutosEF.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Usuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nm_Usuario");

                    b.HasKey("Id");

                    b.ToTable("tblUsuario");
                });

            modelBuilder.Entity("ProdutosEF.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Venda")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("Id_Usuario");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Vlr_Total");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("tblVenda");
                });

            modelBuilder.Entity("ProdutosEF.Models.VendaItem", b =>
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

            modelBuilder.Entity("ProdutosEF.Models.Venda", b =>
                {
                    b.HasOne("ProdutosEF.Models.Usuario", "Usuario")
                        .WithMany("Vendas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProdutosEF.Models.VendaItem", b =>
                {
                    b.HasOne("ProdutosEF.Models.Produto", "Produto")
                        .WithMany("ItensDoProdutoVendido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProdutosEF.Models.Venda", "Venda")
                        .WithMany("Itens")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("ProdutosEF.Models.Produto", b =>
                {
                    b.Navigation("ItensDoProdutoVendido");
                });

            modelBuilder.Entity("ProdutosEF.Models.Usuario", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("ProdutosEF.Models.Venda", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}