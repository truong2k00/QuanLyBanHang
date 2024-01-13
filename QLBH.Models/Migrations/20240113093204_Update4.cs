using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment_Product",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(type: "bigint", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    star = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Product_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Image_Comment",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment_ProductID = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Comment_Comment_Product_Comment_ProductID",
                        column: x => x.Comment_ProductID,
                        principalTable: "Comment_Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Product_ProductID",
                table: "Comment_Product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Comment_Comment_ProductID",
                table: "Image_Comment",
                column: "Comment_ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image_Comment");

            migrationBuilder.DropTable(
                name: "Comment_Product");
        }
    }
}
