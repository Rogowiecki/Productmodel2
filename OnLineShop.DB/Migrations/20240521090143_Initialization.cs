using Microsoft.EntityFrameworkCore.Migrations;

namespace OnLineShop.DB.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    URLImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardDBItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CartDBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDBItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardDBItems_CartDBs_CartDBId",
                        column: x => x.CartDBId,
                        principalTable: "CartDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardDBItems_ProductDBs_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardDBItems_CartDBId",
                table: "CardDBItems",
                column: "CartDBId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDBItems_ProductId",
                table: "CardDBItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDBItems");

            migrationBuilder.DropTable(
                name: "CartDBs");

            migrationBuilder.DropTable(
                name: "ProductDBs");
        }
    }
}
