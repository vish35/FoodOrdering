using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodordering.Migrations
{
    public partial class updatedfooditemmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_url",
                table: "FoodItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "id",
                keyValue: 1,
                column: "img_url",
                value: "C:\\Users]\\Vishakha.Karimungi\\OneDrive - MINDBODY, Inc\\Documents\\Food_images\\ovenstorypizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_url",
                table: "FoodItem");
        }
    }
}
