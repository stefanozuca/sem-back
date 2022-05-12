using Microsoft.EntityFrameworkCore.Migrations;

namespace Sem.Persistance.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Counters");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Counters",
                newName: "Trabajadores");

            migrationBuilder.AddColumn<int>(
                name: "Felices",
                table: "Counters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Horas",
                table: "Counters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Proyectos",
                table: "Counters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Felices",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "Horas",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "Proyectos",
                table: "Counters");

            migrationBuilder.RenameColumn(
                name: "Trabajadores",
                table: "Counters",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Counters",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
