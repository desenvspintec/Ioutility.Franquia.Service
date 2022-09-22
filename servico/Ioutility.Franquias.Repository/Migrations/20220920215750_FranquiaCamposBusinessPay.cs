using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class FranquiaCamposBusinessPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RazaoSocial",
                table: "Franquia",
                newName: "BusinessPay_ConfiguracaoCartao");

            migrationBuilder.AlterColumn<int>(
                name: "Endereco_Numero",
                table: "Franquia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BusinessPay_NrVendasMes",
                table: "Franquia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessPay_NrVendasMes",
                table: "Franquia");

            migrationBuilder.RenameColumn(
                name: "BusinessPay_ConfiguracaoCartao",
                table: "Franquia",
                newName: "RazaoSocial");

            migrationBuilder.AlterColumn<int>(
                name: "Endereco_Numero",
                table: "Franquia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
