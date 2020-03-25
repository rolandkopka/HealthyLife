using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyLife.Data.Migrations
{
    public partial class RenameIngredientProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloryIn100G",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CarboHydrateIn100G",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "FatIn100G",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ProteinIn100G",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "Calory",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrate",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calory", "Carbohydrate", "Fat", "Protein" },
                values: new object[] { 143, 0.69999999999999996, 9.5, 13.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calory",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Carbohydrate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "CaloryIn100G",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CarboHydrateIn100G",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FatIn100G",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProteinIn100G",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CaloryIn100G", "CarboHydrateIn100G", "FatIn100G", "ProteinIn100G" },
                values: new object[] { 143, 0.69999999999999996, 9.5, 13.0 });
        }
    }
}
