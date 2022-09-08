using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventSource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityReferenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayNameDaEntityReferente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JsonDados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoOperacaoCrud = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franquia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco_Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: true),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Uf = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Endereco_Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Endereco_Arquivos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeQuery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeSemPreposicaoQuery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franquia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSource");

            migrationBuilder.DropTable(
                name: "Franquia");
        }
    }
}
