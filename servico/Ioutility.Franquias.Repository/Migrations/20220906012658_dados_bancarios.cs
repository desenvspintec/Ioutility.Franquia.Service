using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class dados_bancarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DadoBancario_Agencia",
                table: "Franquia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DadoBancario_BancoId",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DadoBancario_ChavePix",
                table: "Franquia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DadoBancario_Conta",
                table: "Franquia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DadoBancario_TipoChavePix",
                table: "Franquia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadoBancario_Agencia",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "DadoBancario_BancoId",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "DadoBancario_ChavePix",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "DadoBancario_Conta",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "DadoBancario_TipoChavePix",
                table: "Franquia");
        }
    }
}
