using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class ProcedimentosMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoProcedimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeQuery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeSemPreposicaoQuery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProcedimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Especialidade = table.Column<int>(type: "int", nullable: false),
                    TipoProcedimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor_Sugerido = table.Column<double>(type: "float", nullable: false),
                    Valor_Minimo = table.Column<double>(type: "float", nullable: false),
                    Valor_Maximo = table.Column<double>(type: "float", nullable: false),
                    Valor_CustoAdicional = table.Column<double>(type: "float", nullable: false),
                    Comissao_Tipo = table.Column<int>(type: "int", nullable: false),
                    Comissao_Valor = table.Column<double>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedimento_TipoProcedimento_TipoProcedimentoId",
                        column: x => x.TipoProcedimentoId,
                        principalTable: "TipoProcedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_TipoProcedimentoId",
                table: "Procedimento",
                column: "TipoProcedimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "TipoProcedimento");
        }
    }
}
