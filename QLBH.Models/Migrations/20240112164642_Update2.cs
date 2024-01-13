using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MailSettingID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "MailSetting",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailSetting", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_MailSettingID",
                table: "ConfirmEmail",
                column: "MailSettingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_MailSetting_MailSettingID",
                table: "ConfirmEmail",
                column: "MailSettingID",
                principalTable: "MailSetting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_MailSetting_MailSettingID",
                table: "ConfirmEmail");

            migrationBuilder.DropTable(
                name: "MailSetting");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmEmail_MailSettingID",
                table: "ConfirmEmail");

            migrationBuilder.DropColumn(
                name: "MailSettingID",
                table: "ConfirmEmail");
        }
    }
}
