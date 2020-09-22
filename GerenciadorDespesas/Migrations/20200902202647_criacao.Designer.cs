﻿// <auto-generated />
using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciadorDespesas.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200902202647_criacao")]
    partial class criacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciadorDespesas.Models.Despesa", b =>
                {
                    b.Property<int>("DespesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDespesaId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("DespesaId");

                    b.HasIndex("MesId");

                    b.HasIndex("TipoDespesaId");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Meses", b =>
                {
                    b.Property<int>("MesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("MesId");

                    b.ToTable("Meses");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Salarios", b =>
                {
                    b.Property<int>("SalarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("SalarioId");

                    b.HasIndex("MesId")
                        .IsUnique();

                    b.ToTable("Salarios");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.TipoDespesas", b =>
                {
                    b.Property<int>("TipoDespesasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TipoDespesasId");

                    b.ToTable("TipoDespesas");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Despesa", b =>
                {
                    b.HasOne("GerenciadorDespesas.Models.Meses", "Meses")
                        .WithMany("Despesas")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciadorDespesas.Models.TipoDespesas", "TipoDespesas")
                        .WithMany("Despesas")
                        .HasForeignKey("TipoDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Salarios", b =>
                {
                    b.HasOne("GerenciadorDespesas.Models.Meses", "Meses")
                        .WithOne("Salarios")
                        .HasForeignKey("GerenciadorDespesas.Models.Salarios", "MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
