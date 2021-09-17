using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodordering.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevOrders_FoodItem_itemid",
                table: "PrevOrders");

            migrationBuilder.DropIndex(
                name: "IX_PrevOrders_itemid",
                table: "PrevOrders");

            migrationBuilder.RenameColumn(
                name: "itemid",
                table: "PrevOrders",
                newName: "Itemid");

            migrationBuilder.AlterColumn<int>(
                name: "Itemid",
                table: "PrevOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "porder",
                table: "PrevOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrevOrders",
                table: "PrevOrders",
                column: "porder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrevOrders",
                table: "PrevOrders");

            migrationBuilder.DropColumn(
                name: "porder",
                table: "PrevOrders");

            migrationBuilder.RenameColumn(
                name: "Itemid",
                table: "PrevOrders",
                newName: "itemid");

            migrationBuilder.AlterColumn<int>(
                name: "itemid",
                table: "PrevOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PrevOrders_itemid",
                table: "PrevOrders",
                column: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevOrders_FoodItem_itemid",
                table: "PrevOrders",
                column: "itemid",
                principalTable: "FoodItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
