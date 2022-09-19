using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ioutility.Franquias.Repository.Migrations
{
    public partial class addcamposfranquia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DadoBancario_TipoChavePix",
                table: "Franquia",
                newName: "DadosBancarios_TipoChavePix");

            migrationBuilder.RenameColumn(
                name: "DadoBancario_Conta",
                table: "Franquia",
                newName: "DadosBancarios_Conta");

            migrationBuilder.RenameColumn(
                name: "DadoBancario_ChavePix",
                table: "Franquia",
                newName: "DadosBancarios_ChavePix");

            migrationBuilder.RenameColumn(
                name: "DadoBancario_BancoId",
                table: "Franquia",
                newName: "DadosBancarios_BancoId");

            migrationBuilder.RenameColumn(
                name: "DadoBancario_Agencia",
                table: "Franquia",
                newName: "DadosBancarios_Agencia");

            migrationBuilder.AlterColumn<int>(
                name: "Endereco_Numero",
                table: "Franquia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco_Complemento",
                table: "Franquia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Acesso_FranquiaStatus",
                table: "Franquia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CelularWhatsApp",
                table: "Franquia",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Franquia",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsavelLegal",
                table: "Franquia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Franquia",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acesso_FranquiaStatus",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "CelularWhatsApp",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "ResponsavelLegal",
                table: "Franquia");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Franquia");

            migrationBuilder.RenameColumn(
                name: "DadosBancarios_TipoChavePix",
                table: "Franquia",
                newName: "DadoBancario_TipoChavePix");

            migrationBuilder.RenameColumn(
                name: "DadosBancarios_Conta",
                table: "Franquia",
                newName: "DadoBancario_Conta");

            migrationBuilder.RenameColumn(
                name: "DadosBancarios_ChavePix",
                table: "Franquia",
                newName: "DadoBancario_ChavePix");

            migrationBuilder.RenameColumn(
                name: "DadosBancarios_BancoId",
                table: "Franquia",
                newName: "DadoBancario_BancoId");

            migrationBuilder.RenameColumn(
                name: "DadosBancarios_Agencia",
                table: "Franquia",
                newName: "DadoBancario_Agencia");

            migrationBuilder.AlterColumn<int>(
                name: "Endereco_Numero",
                table: "Franquia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco_Complemento",
                table: "Franquia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
