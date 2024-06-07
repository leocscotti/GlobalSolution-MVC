using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution_MVC.Migrations
{
    /// <inheritdoc />
    public partial class vAtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_autoridade_ambiental",
                columns: table => new
                {
                    ID_Autoridade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_autoridade_ambiental = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ds_autoridade_ambiental = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_autoridade_ambiental", x => x.ID_Autoridade);
                });

            migrationBuilder.CreateTable(
                name: "tb_localizacao",
                columns: table => new
                {
                    ID_Localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    latitude = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    longitude = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ds_localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_localizacao", x => x.ID_Localizacao);
                });

            migrationBuilder.CreateTable(
                name: "tb_residuo",
                columns: table => new
                {
                    ID_Residuo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_residuo = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    tp_residuo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_residuo", x => x.ID_Residuo);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_usuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.ID_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_autoridade_ambiental_denuncia",
                columns: table => new
                {
                    ID_AutoridadeDenuncia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DenunciaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AutoridadeAmbientalId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_autoridade_ambiental_denuncia", x => x.ID_AutoridadeDenuncia);
                    table.ForeignKey(
                        name: "FK_tb_autoridade_ambiental_denuncia_tb_autoridade_ambiental_AutoridadeAmbientalId",
                        column: x => x.AutoridadeAmbientalId,
                        principalTable: "tb_autoridade_ambiental",
                        principalColumn: "ID_Autoridade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_comentario",
                columns: table => new
                {
                    ID_Comentario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_comentario = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    tp_comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DenunciaId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_comentario", x => x.ID_Comentario);
                });

            migrationBuilder.CreateTable(
                name: "tb_notificacao",
                columns: table => new
                {
                    ID_Notificacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_comentario = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    st_comentario = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    tp_comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ComentarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_notificacao", x => x.ID_Notificacao);
                    table.ForeignKey(
                        name: "FK_tb_notificacao_tb_comentario_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "tb_comentario",
                        principalColumn: "ID_Comentario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_denuncia",
                columns: table => new
                {
                    ID_Denuncia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_ocorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ds_denuncia = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    st_denuncia = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AutoridadeAmbientalId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NotificacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_denuncia", x => x.ID_Denuncia);
                    table.ForeignKey(
                        name: "FK_tb_denuncia_tb_autoridade_ambiental_AutoridadeAmbientalId",
                        column: x => x.AutoridadeAmbientalId,
                        principalTable: "tb_autoridade_ambiental",
                        principalColumn: "ID_Autoridade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_denuncia_tb_localizacao_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "tb_localizacao",
                        principalColumn: "ID_Localizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_denuncia_tb_notificacao_NotificacaoId",
                        column: x => x.NotificacaoId,
                        principalTable: "tb_notificacao",
                        principalColumn: "ID_Notificacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_denuncia_tb_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_usuario",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_autoridade_ambiental_denuncia_AutoridadeAmbientalId",
                table: "tb_autoridade_ambiental_denuncia",
                column: "AutoridadeAmbientalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_autoridade_ambiental_denuncia_DenunciaId",
                table: "tb_autoridade_ambiental_denuncia",
                column: "DenunciaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_comentario_DenunciaId",
                table: "tb_comentario",
                column: "DenunciaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_denuncia_AutoridadeAmbientalId",
                table: "tb_denuncia",
                column: "AutoridadeAmbientalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_denuncia_LocalizacaoId",
                table: "tb_denuncia",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_denuncia_NotificacaoId",
                table: "tb_denuncia",
                column: "NotificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_denuncia_UsuarioId",
                table: "tb_denuncia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_notificacao_ComentarioId",
                table: "tb_notificacao",
                column: "ComentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_autoridade_ambiental_denuncia_tb_denuncia_DenunciaId",
                table: "tb_autoridade_ambiental_denuncia",
                column: "DenunciaId",
                principalTable: "tb_denuncia",
                principalColumn: "ID_Denuncia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_comentario_tb_denuncia_DenunciaId",
                table: "tb_comentario",
                column: "DenunciaId",
                principalTable: "tb_denuncia",
                principalColumn: "ID_Denuncia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_denuncia_tb_autoridade_ambiental_AutoridadeAmbientalId",
                table: "tb_denuncia");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_comentario_tb_denuncia_DenunciaId",
                table: "tb_comentario");

            migrationBuilder.DropTable(
                name: "tb_autoridade_ambiental_denuncia");

            migrationBuilder.DropTable(
                name: "tb_residuo");

            migrationBuilder.DropTable(
                name: "tb_autoridade_ambiental");

            migrationBuilder.DropTable(
                name: "tb_denuncia");

            migrationBuilder.DropTable(
                name: "tb_localizacao");

            migrationBuilder.DropTable(
                name: "tb_notificacao");

            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_comentario");
        }
    }
}
