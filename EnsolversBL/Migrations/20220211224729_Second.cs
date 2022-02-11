using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsolversBL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Users",
                newName: "Active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "Activo");
        }
    }
}
