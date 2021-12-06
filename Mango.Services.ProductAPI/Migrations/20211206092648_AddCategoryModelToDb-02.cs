using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.ProductAPI.Migrations
{
    public partial class AddCategoryModelToDb02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producs_Categories_CategoryId",
                table: "Producs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producs",
                table: "Producs");

            migrationBuilder.RenameTable(
                name: "Producs",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Producs_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Producs");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Producs",
                newName: "IX_Producs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producs",
                table: "Producs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producs_Categories_CategoryId",
                table: "Producs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
