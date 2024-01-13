using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_RoleID",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_RoleID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Role_ID",
                table: "Account");

            migrationBuilder.AddColumn<long>(
                name: "RoleID",
                table: "Decentralization",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decentralization_RoleID",
                table: "Decentralization",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization");

            migrationBuilder.DropIndex(
                name: "IX_Decentralization_RoleID",
                table: "Decentralization");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Decentralization");

            migrationBuilder.AddColumn<long>(
                name: "RoleID",
                table: "Account",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Role_ID",
                table: "Account",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleID",
                table: "Account",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_RoleID",
                table: "Account",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID");
        }
    }
}
