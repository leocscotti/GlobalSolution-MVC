using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution_MVC.Migrations
{
    /// <inheritdoc />
    public partial class v0306 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoridadesAmbientais",
                columns: table => new
                {
                    ID_Autoridade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoridadesAmbientais", x => x.ID_Autoridade);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    ID_Localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Pais = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.ID_Localizacao);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    ID_Denuncia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo_Poluicao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Data_Hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.ID_Denuncia);
                    table.ForeignKey(
                        name: "FK_Denuncias_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "ID_Localizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoridadeAmbientalDenuncia",
                columns: table => new
                {
                    ID_AutoridadeDenuncia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DenunciaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AutoridadeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoridadeAmbientalDenuncia", x => x.ID_AutoridadeDenuncia);
                    table.ForeignKey(
                        name: "FK_AutoridadeAmbientalDenuncia_AutoridadesAmbientais_AutoridadeId",
                        column: x => x.AutoridadeId,
                        principalTable: "AutoridadesAmbientais",
                        principalColumn: "ID_Autoridade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoridadeAmbientalDenuncia_Denuncias_DenunciaId",
                        column: x => x.DenunciaId,
                        principalTable: "Denuncias",
                        principalColumn: "ID_Denuncia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ID_Comentario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Conteudo = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Data_Hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DenunciaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ID_Comentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Denuncias_DenunciaId",
                        column: x => x.DenunciaId,
                        principalTable: "Denuncias",
                        principalColumn: "ID_Denuncia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoridadeAmbientalDenuncia_AutoridadeId",
                table: "AutoridadeAmbientalDenuncia",
                column: "AutoridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoridadeAmbientalDenuncia_DenunciaId",
                table: "AutoridadeAmbientalDenuncia",
                column: "DenunciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_DenunciaId",
                table: "Comentarios",
                column: "DenunciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_LocalizacaoId",
                table: "Denuncias",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_UsuarioId",
                table: "Denuncias",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoridadeAmbientalDenuncia");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "AutoridadesAmbientais");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
