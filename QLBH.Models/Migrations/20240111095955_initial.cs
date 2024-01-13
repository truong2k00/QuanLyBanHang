using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCatogory",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catogory_ID = table.Column<long>(type: "bigint", nullable: false),
                    CatogoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatogory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_ID = table.Column<long>(type: "bigint", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status_Bill",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_ID = table.Column<long>(type: "bigint", nullable: false),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Bill", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<long>(type: "bigint", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_ID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: true),
                    Work = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Addess_Receive",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addess_Receive_ID = table.Column<long>(type: "bigint", nullable: false),
                    Addess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirm = table.Column<bool>(type: "bit", nullable: false),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addess_Receive", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addess_Receive_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<long>(type: "bigint", nullable: false),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cart_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedBack_ID = table.Column<long>(type: "bigint", nullable: false),
                    FeedBack_Quality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FeedBack_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notification_ID = table.Column<long>(type: "bigint", nullable: false),
                    Notification_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notification_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notification_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<long>(type: "bigint", nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meta_Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catogory_ID = table.Column<long>(type: "bigint", nullable: false),
                    ProductCatogoryID = table.Column<long>(type: "bigint", nullable: true),
                    Is_New = table.Column<bool>(type: "bit", nullable: false),
                    Sale = table.Column<bool>(type: "bit", nullable: false),
                    Date_Delete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Price_Sale = table.Column<long>(type: "bigint", nullable: true),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true),
                    Evaluate = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_ProductCatogory_ProductCatogoryID",
                        column: x => x.ProductCatogoryID,
                        principalTable: "ProductCatogory",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RefeshToken",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefeshToken_ID = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Expired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeshToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RefeshToken_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<long>(type: "bigint", nullable: false),
                    VoucherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Reducted_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true),
                    Work = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Voucher_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill_ID = table.Column<long>(type: "bigint", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_ID = table.Column<long>(type: "bigint", nullable: false),
                    Status_BillID = table.Column<long>(type: "bigint", nullable: true),
                    Acount_ID = table.Column<long>(type: "bigint", nullable: false),
                    AcountID = table.Column<long>(type: "bigint", nullable: true),
                    Addess_Receive_ID = table.Column<long>(type: "bigint", nullable: false),
                    Addess_ReceiveID = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bill_Account_AcountID",
                        column: x => x.AcountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bill_Addess_Receive_Addess_ReceiveID",
                        column: x => x.Addess_ReceiveID,
                        principalTable: "Addess_Receive",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bill_Status_Bill_Status_BillID",
                        column: x => x.Status_BillID,
                        principalTable: "Status_Bill",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ConfirmEmail",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmEmail_ID = table.Column<long>(type: "bigint", nullable: false),
                    CodeiVerification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Account_ID = table.Column<long>(type: "bigint", nullable: false),
                    AccountID = table.Column<long>(type: "bigint", nullable: true),
                    Addess_Receive_ID = table.Column<long>(type: "bigint", nullable: false),
                    Addess_ReceiveID = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmEmail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConfirmEmail_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConfirmEmail_Addess_Receive_Addess_ReceiveID",
                        column: x => x.Addess_ReceiveID,
                        principalTable: "Addess_Receive",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Detail_Cart",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail_Cart_ID = table.Column<long>(type: "bigint", nullable: false),
                    Cart_ID = table.Column<long>(type: "bigint", nullable: false),
                    CartID = table.Column<long>(type: "bigint", nullable: true),
                    Product_ID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Detail_Cart_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Detail_Cart_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail_ID = table.Column<long>(type: "bigint", nullable: false),
                    Introduce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_Introduce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_ID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Details_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ImageProduct",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_ID = table.Column<long>(type: "bigint", nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_ID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Details",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_Id = table.Column<long>(type: "bigint", nullable: false),
                    Product_ID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bill_ID = table.Column<long>(type: "bigint", nullable: false),
                    BillID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Bill_BillID",
                        column: x => x.BillID,
                        principalTable: "Bill",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleID",
                table: "Account",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Addess_Receive_AcountID",
                table: "Addess_Receive",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_AcountID",
                table: "Bill",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Addess_ReceiveID",
                table: "Bill",
                column: "Addess_ReceiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Status_BillID",
                table: "Bill",
                column: "Status_BillID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_AcountID",
                table: "Cart",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_AccountID",
                table: "ConfirmEmail",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_Addess_ReceiveID",
                table: "ConfirmEmail",
                column: "Addess_ReceiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Cart_CartID",
                table: "Detail_Cart",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Cart_ProductID",
                table: "Detail_Cart",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductID",
                table: "Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_AcountID",
                table: "FeedBack",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProduct_ProductID",
                table: "ImageProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_BillID",
                table: "Invoice_Details",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_ProductID",
                table: "Invoice_Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AcountID",
                table: "Notification",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AcountID",
                table: "Product",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCatogoryID",
                table: "Product",
                column: "ProductCatogoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RefeshToken_AcountID",
                table: "RefeshToken",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_AcountID",
                table: "Voucher",
                column: "AcountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmEmail");

            migrationBuilder.DropTable(
                name: "Detail_Cart");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "ImageProduct");

            migrationBuilder.DropTable(
                name: "Invoice_Details");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RefeshToken");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Addess_Receive");

            migrationBuilder.DropTable(
                name: "Status_Bill");

            migrationBuilder.DropTable(
                name: "ProductCatogory");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
