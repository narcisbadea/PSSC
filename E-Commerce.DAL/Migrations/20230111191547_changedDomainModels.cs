using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class changedDomainModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_ItemTypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Items",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                newName: "IX_Items_TypeId");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Items",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                newName: "IX_Items_ItemTypeId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Adress");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
