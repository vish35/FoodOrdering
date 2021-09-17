using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodordering.Migrations
{
    public partial class updatedfooditemmodel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "id",
                keyValue: 1,
                column: "img_url",
                value: "C:\\Users\\Vishakha.Karimungi\\OneDrive - MINDBODY, Inc\\Documents\\Food_images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "id",
                keyValue: 1,
                column: "img_url",
                value: "C:\\Users]\\Vishakha.Karimungi\\OneDrive - MINDBODY, Inc\\Documents\\Food_images\\ovenstorypizza");
        }
    }
}
