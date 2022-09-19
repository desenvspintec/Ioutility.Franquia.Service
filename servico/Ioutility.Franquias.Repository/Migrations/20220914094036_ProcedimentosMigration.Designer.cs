﻿// <auto-generated />
using System;
using Ioutility.Franquias.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    [DbContext(typeof(FranquiaDb))]
    [Migration("20220914094036_ProcedimentosMigration")]
    partial class ProcedimentosMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ioutility.Franquias.Domain.Franquias.Models.Franquia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeQuery")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeSemPreposicaoQuery")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Franquia", (string)null);
                });

            modelBuilder.Entity("Ioutility.Franquias.Domain.Procedimentos.Models.Procedimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Especialidade")
                        .HasColumnType("int");

                    b.Property<Guid>("TipoProcedimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TipoProcedimentoId");

                    b.ToTable("Procedimento", (string)null);
                });

            modelBuilder.Entity("Ioutility.Franquias.Domain.Procedimentos.Models.TipoProcedimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeQuery")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeSemPreposicaoQuery")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoProcedimento", (string)null);
                });

            modelBuilder.Entity("Pulsati.Core.Domain.EventSources.EventSource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayNameDaEntityReferente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EntityReferenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JsonDados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoOperacaoCrud")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EventSource", (string)null);
                });

            modelBuilder.Entity("Ioutility.Franquias.Domain.Franquias.Models.Franquia", b =>
                {
                    b.OwnsOne("Ioutility.Franquias.Domain.Franquias.Models.FranquiaDadoBancario", "DadoBancario", b1 =>
                        {
                            b1.Property<Guid>("FranquiaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Agencia")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("BancoId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ChavePix")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Conta")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<int>("TipoChavePix")
                                .HasColumnType("int");

                            b1.HasKey("FranquiaId");

                            b1.ToTable("Franquia");

                            b1.WithOwner()
                                .HasForeignKey("FranquiaId");
                        });

                    b.OwnsOne("Pulsati.Core.Domain.ValueObjects.Enderecos.EnderecoVO", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("FranquiaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Arquivos")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("Numero")
                                .HasColumnType("int");

                            b1.Property<string>("Uf")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("nvarchar(5)");

                            b1.HasKey("FranquiaId");

                            b1.ToTable("Franquia");

                            b1.WithOwner()
                                .HasForeignKey("FranquiaId");
                        });

                    b.Navigation("DadoBancario")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("Ioutility.Franquias.Domain.Procedimentos.Models.Procedimento", b =>
                {
                    b.HasOne("Ioutility.Franquias.Domain.Procedimentos.Models.TipoProcedimento", "TipoProcedimento")
                        .WithMany("Procedimentos")
                        .HasForeignKey("TipoProcedimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Ioutility.Franquias.Domain.Procedimentos.Models.ProcedimentoComissaoVO", "Comissao", b1 =>
                        {
                            b1.Property<Guid>("ProcedimentoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Tipo")
                                .HasColumnType("int");

                            b1.Property<double>("Valor")
                                .HasColumnType("float");

                            b1.HasKey("ProcedimentoId");

                            b1.ToTable("Procedimento");

                            b1.WithOwner()
                                .HasForeignKey("ProcedimentoId");
                        });

                    b.OwnsOne("Ioutility.Franquias.Domain.Procedimentos.Models.ProcedimentoValorVO", "Valor", b1 =>
                        {
                            b1.Property<Guid>("ProcedimentoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("CustoAdicional")
                                .HasColumnType("float");

                            b1.Property<double>("Maximo")
                                .HasColumnType("float");

                            b1.Property<double>("Minimo")
                                .HasColumnType("float");

                            b1.Property<double>("Sugerido")
                                .HasColumnType("float");

                            b1.HasKey("ProcedimentoId");

                            b1.ToTable("Procedimento");

                            b1.WithOwner()
                                .HasForeignKey("ProcedimentoId");
                        });

                    b.Navigation("Comissao")
                        .IsRequired();

                    b.Navigation("TipoProcedimento");

                    b.Navigation("Valor")
                        .IsRequired();
                });

            modelBuilder.Entity("Ioutility.Franquias.Domain.Procedimentos.Models.TipoProcedimento", b =>
                {
                    b.Navigation("Procedimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
