using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.ProductAPI.Migrations
{
    public partial class AddCategoryModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_producs",
                table: "producs");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "producs");

            migrationBuilder.RenameTable(
                name: "producs",
                newName: "Producs");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Producs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producs",
                table: "Producs",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentId" },
                values: new object[] { 1, "Dinner", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentId" },
                values: new object[] { 2, "Launch", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentId" },
                values: new object[] { 3, "apetizer", 0 });

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Producs_CategoryId",
                table: "Producs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producs_Categories_CategoryId",
                table: "Producs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producs_Categories_CategoryId",
                table: "Producs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producs",
                table: "Producs");

            migrationBuilder.DropIndex(
                name: "IX_Producs_CategoryId",
                table: "Producs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Producs");

            migrationBuilder.RenameTable(
                name: "Producs",
                newName: "producs");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "producs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_producs",
                table: "producs",
                column: "ProductId");

            migrationBuilder.UpdateData(
                table: "producs",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CategoryName",
                value: "Appetizer");

            migrationBuilder.UpdateData(
                table: "producs",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CategoryName",
                value: "Appetizer");

            migrationBuilder.UpdateData(
                table: "producs",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CategoryName",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "producs",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CategoryName",
                value: "Entree");
        }
    }
}
