﻿// <auto-generated />
using System;
using GlobalSolution_MVC.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace GlobalSolution_MVC.Migrations
{
    [DbContext(typeof(VisionaryBlueDbContext))]
    [Migration("20240603172652_v0306")]
    partial class v0306
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GlobalSolution_MVC.Models.AutoridadeAmbiental", b =>
                {
                    b.Property<int>("AutoridadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_Autoridade");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoridadeId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Nome");

                    b.HasKey("AutoridadeId");

                    b.ToTable("AutoridadesAmbientais");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.AutoridadeAmbientalDenuncia", b =>
                {
                    b.Property<int>("AutoridadeDenunciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_AutoridadeDenuncia");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoridadeDenunciaId"));

                    b.Property<int>("AutoridadeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("DenunciaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("AutoridadeDenunciaId");

                    b.HasIndex("AutoridadeId");

                    b.HasIndex("DenunciaId");

                    b.ToTable("AutoridadeAmbientalDenuncia");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_Comentario");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComentarioId"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)")
                        .HasColumnName("Conteudo");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Hora");

                    b.Property<int>("DenunciaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ComentarioId");

                    b.HasIndex("DenunciaId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Denuncia", b =>
                {
                    b.Property<int>("DenunciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_Denuncia");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DenunciaId"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Hora");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)")
                        .HasColumnName("Descricao");

                    b.Property<int>("LocalizacaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Status");

                    b.Property<string>("TipoPoluicao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("Tipo_Poluicao");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("DenunciaId");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Denuncias");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Localizacao", b =>
                {
                    b.Property<int>("LocalizacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_Localizacao");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalizacaoId"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Estado");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Pais");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Rua");

                    b.HasKey("LocalizacaoId");

                    b.ToTable("Localizacoes");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_Usuario");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Nome");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.AutoridadeAmbientalDenuncia", b =>
                {
                    b.HasOne("GlobalSolution_MVC.Models.AutoridadeAmbiental", "Autoridade")
                        .WithMany("DenunciasParaAnalise")
                        .HasForeignKey("AutoridadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GlobalSolution_MVC.Models.Denuncia", "Denuncia")
                        .WithMany("Autoridades")
                        .HasForeignKey("DenunciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autoridade");

                    b.Navigation("Denuncia");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Comentario", b =>
                {
                    b.HasOne("GlobalSolution_MVC.Models.Denuncia", "Denuncia")
                        .WithMany("Comentarios")
                        .HasForeignKey("DenunciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Denuncia");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Denuncia", b =>
                {
                    b.HasOne("GlobalSolution_MVC.Models.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GlobalSolution_MVC.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.AutoridadeAmbiental", b =>
                {
                    b.Navigation("DenunciasParaAnalise");
                });

            modelBuilder.Entity("GlobalSolution_MVC.Models.Denuncia", b =>
                {
                    b.Navigation("Autoridades");

                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}