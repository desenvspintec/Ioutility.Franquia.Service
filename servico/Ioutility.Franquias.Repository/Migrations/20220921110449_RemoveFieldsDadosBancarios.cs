using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class RemoveFieldsDadosBancarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadosBancarios_BancoNome",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "DadosBancarios_SalarioMensal",
                table: "Franquia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DadosBancarios_BancoNome",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "DadosBancarios_SalarioMensal",
                table: "Franquia",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
