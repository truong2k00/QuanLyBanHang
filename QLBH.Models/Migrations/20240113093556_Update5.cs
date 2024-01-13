using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "star",
                table: "FeedBack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "AccountID",
                table: "Comment_Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Product_AccountID",
                table: "Comment_Product",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_Account_AccountID",
                table: "Comment_Product",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_Account_AccountID",
                table: "Comment_Product");

            migrationBuilder.DropIndex(
                name: "IX_Comment_Product_AccountID",
                table: "Comment_Product");

            migrationBuilder.DropColumn(
                name: "star",
                table: "FeedBack");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Comment_Product");
        }
    }
}
