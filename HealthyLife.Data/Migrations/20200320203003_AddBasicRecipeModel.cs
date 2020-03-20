using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyLife.Data.Migrations
{
    public partial class AddBasicRecipeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaloryIn100G",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CarboHydrateIn100G",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FatIn100G",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProteinIn100G",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Servings = table.Column<int>(nullable: false),
                    ReadyInMinutes = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CaloryIn100G", "CarboHydrateIn100G", "FatIn100G", "Name", "ProteinIn100G" },
                values: new object[] { 143, 0.69999999999999996, 9.5, "Large Egg", 13.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Salt");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Instructions", "Picture", "ReadyInMinutes", "Servings", "Title" },
                values: new object[] { 1, "Crack the eggs into the hot pan and salt them. Cook both sides of the eggs for 2-2 minutes.", "https://pixabay.com/get/55e6d7474350a914f6d1867dda6d49214b6ac3e45659754e762f7cd095/fried-3624925_1920.jpg", 5, 1, "Fried Egg" });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId", "Unit" },
                values: new object[] { 1, 4.0, 1, 1, "" });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId", "Unit" },
                values: new object[] { 2, 0.5, 2, 1, "tsp" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Recipes");

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

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Salt");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pepper");
        }
    }
}
