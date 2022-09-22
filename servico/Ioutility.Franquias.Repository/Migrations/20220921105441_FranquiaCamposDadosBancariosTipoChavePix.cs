using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class FranquiaCamposDadosBancariosTipoChavePix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DadosBancarios_TipoChavePixTxt",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadosBancarios_TipoChavePixTxt",
                table: "Franquia");
        }
    }
}
