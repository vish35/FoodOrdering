using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodordering.Migrations
{
    public partial class mealtypemg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.MealId);
                });

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "id",
                keyValue: 1,
                column: "mealType",
                value: 1);

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "MealId", "Description", "MealName" },
                values: new object[,]
                {
                    { 1, "", "BRUNCH" },
                    { 2, "", "ELEVENSES" },
                    { 3, "", "LUNCH" },
                    { 4, "", "DINNER" },
                    { 5, "", "SUPPER" },
                    { 6, "", "AFTERNOON_TEA" },
                    { 7, "", "HIGH_TEA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "id",
                keyValue: 1,
                column: "mealType",
                value: 2);
        }
    }
}
