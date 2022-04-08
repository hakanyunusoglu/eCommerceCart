using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Persistence.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersAddresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAddresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userAddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersInfo_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInfo_UsersAddresses_userAddressID",
                        column: x => x.userAddressID,
                        principalTable: "UsersAddresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_cartID",
                        column: x => x.cartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerLists",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SellerLists_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "ID", "CreatedDate", "userID" },
                values: new object[] { new Guid("b6685975-1700-4898-8f45-d60b8a12dc8d"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6997), new Guid("97ab0c42-b728-11ec-b909-0242ac120002") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("c557e1ce-b638-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6796), "Electronic Equipment", "Computer" },
                    { new Guid("db9572ee-b638-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6805), "Electronic Small Equipment", "Tablet" },
                    { new Guid("e275007a-b638-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6809), "Electronic Smart Equipment", "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("97ab0c42-b728-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6499), new byte[] { 103, 128, 62, 221, 173, 71, 80, 247, 100, 78, 51, 135, 158, 189, 220, 4, 113, 230, 125, 172, 38, 33, 182, 184, 188, 110, 163, 38, 60, 167, 95, 179, 45, 148, 210, 109, 251, 48, 216, 252, 173, 124, 99, 161, 18, 112, 161, 141, 196, 11, 201, 213, 91, 236, 109, 5, 25, 244, 143, 81, 56, 165, 84, 104 }, new byte[] { 60, 156, 104, 254, 224, 194, 73, 170, 243, 156, 165, 3, 188, 103, 162, 181, 138, 224, 165, 189, 140, 220, 117, 250, 224, 188, 50, 171, 18, 200, 164, 58, 120, 93, 49, 182, 137, 181, 59, 4, 186, 120, 224, 250, 142, 240, 96, 218, 27, 63, 118, 117, 43, 208, 120, 191, 221, 139, 200, 66, 130, 118, 198, 174, 133, 178, 57, 147, 253, 85, 6, 73, 143, 1, 214, 155, 132, 17, 125, 13, 43, 136, 244, 124, 123, 175, 76, 46, 189, 107, 6, 39, 69, 56, 10, 115, 171, 120, 110, 40, 14, 234, 35, 167, 145, 15, 65, 186, 20, 230, 235, 90, 221, 154, 38, 148, 84, 248, 209, 250, 82, 137, 206, 186, 59, 243, 165, 62 }, "hakan" });

            migrationBuilder.InsertData(
                table: "UsersAddresses",
                columns: new[] { "ID", "Address", "City", "CreatedDate" },
                values: new object[] { new Guid("df9b82d0-b75e-11ec-b909-0242ac120002"), "Hadımköy Arnavutköy", "Istanbul", new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CreatedDate", "Description", "Image", "Name", "Title", "categoryID" },
                values: new object[,]
                {
                    { new Guid("415220a0-b639-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6864), "Xiaomi Smart Phone", "productimg/03.jpg", "Mobile Phone", "Smart Phone", new Guid("e275007a-b638-11ec-b909-0242ac120002") },
                    { new Guid("5186d10a-b639-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6872), "Apple new generation", "productimg/02.jpg", "Apple Tablet", "Tablet", new Guid("db9572ee-b638-11ec-b909-0242ac120002") },
                    { new Guid("5d80aa30-b639-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6876), "i7 notebook", "productimg/01.jpg", "Asus Notebook", "Notebook", new Guid("c557e1ce-b638-11ec-b909-0242ac120002") }
                });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "ID", "CreatedDate", "Email", "Name", "Phone", "Surname", "userAddressID", "userID" },
                values: new object[] { new Guid("bc32c678-b75e-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(7032), "hakanyunusoglu93@gmail.com", "Hakan", "0535 555 55 55", "Yunusoğlu", new Guid("df9b82d0-b75e-11ec-b909-0242ac120002"), new Guid("97ab0c42-b728-11ec-b909-0242ac120002") });

            migrationBuilder.InsertData(
                table: "SellerLists",
                columns: new[] { "ID", "CreatedDate", "Price", "Quantity", "productID" },
                values: new object[] { new Guid("6571cb0c-b639-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6919), 4999m, 10, new Guid("415220a0-b639-11ec-b909-0242ac120002") });

            migrationBuilder.InsertData(
                table: "SellerLists",
                columns: new[] { "ID", "CreatedDate", "Price", "Quantity", "productID" },
                values: new object[] { new Guid("6ad5a76c-b639-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6934), 3856m, 5, new Guid("5186d10a-b639-11ec-b909-0242ac120002") });

            migrationBuilder.InsertData(
                table: "SellerLists",
                columns: new[] { "ID", "CreatedDate", "Price", "Quantity", "productID" },
                values: new object[] { new Guid("713aeebe-b639-11ec-b909-0242ac120002"), new DateTime(2022, 4, 8, 23, 30, 53, 632, DateTimeKind.Local).AddTicks(6938), 8999m, 16, new Guid("5d80aa30-b639-11ec-b909-0242ac120002") });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_cartID",
                table: "CartItems",
                column: "cartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_productID",
                table: "CartItems",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_orderID",
                table: "OrderItems",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_productID",
                table: "OrderItems",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userID",
                table: "Orders",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryID",
                table: "Products",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerLists_productID",
                table: "SellerLists",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_userAddressID",
                table: "UsersInfo",
                column: "userAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_userID",
                table: "UsersInfo",
                column: "userID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "SellerLists");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UsersAddresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
