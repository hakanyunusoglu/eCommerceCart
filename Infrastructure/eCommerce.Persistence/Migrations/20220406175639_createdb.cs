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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("53b016e1-5148-403c-a432-0a3dba1f6337"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1872), "Electronic Smart Equipment", "Phone" },
                    { new Guid("76e6dfdb-1fef-4a0a-8e5d-ec0a09bff1aa"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1864), "Electronic Equipment", "Computer" },
                    { new Guid("893ec5d0-02ee-4088-a2cd-088d4edfaa08"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1870), "Electronic Small Equipment", "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CreatedDate", "Description", "Image", "Name", "Title", "categoryID" },
                values: new object[,]
                {
                    { new Guid("a70939ae-5fb2-4e66-8887-7a56046b1bd2"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1906), "Apple new generation", "productimg/02.jpg", "Apple Tablet", "Tablet", new Guid("893ec5d0-02ee-4088-a2cd-088d4edfaa08") },
                    { new Guid("a8ffa6b5-fb0e-47db-8b11-ad6905f9eff2"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1908), "i7 notebook", "productimg/01.jpg", "Asus Notebook", "Notebook", new Guid("76e6dfdb-1fef-4a0a-8e5d-ec0a09bff1aa") },
                    { new Guid("b90751e3-2b9a-430d-a7b2-d1696f1be3b2"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1900), "Xiaomi Smart Phone", "productimg/03.jpg", "Mobile Phone", "Smart Phone", new Guid("53b016e1-5148-403c-a432-0a3dba1f6337") }
                });

            migrationBuilder.InsertData(
                table: "SellerLists",
                columns: new[] { "ID", "CreatedDate", "Price", "Quantity", "productID" },
                values: new object[,]
                {
                    { new Guid("6c005aa1-d6d4-4d86-99d8-07e8dab90240"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1947), 8999m, 16, new Guid("a70939ae-5fb2-4e66-8887-7a56046b1bd2") },
                    { new Guid("cc3ba645-8500-47bb-a95f-58313207e3b8"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1945), 3856m, 5, new Guid("b90751e3-2b9a-430d-a7b2-d1696f1be3b2") },
                    { new Guid("fa54b844-62b2-4d76-b7d1-e40caa542e6d"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1936), 4999m, 10, new Guid("a8ffa6b5-fb0e-47db-8b11-ad6905f9eff2") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("a48da1e6-eece-4ab2-b7ff-ce0a20b24736"), new DateTime(2022, 4, 6, 20, 56, 39, 120, DateTimeKind.Local).AddTicks(1677), new byte[] { 226, 255, 134, 2, 203, 22, 252, 251, 29, 91, 101, 211, 211, 3, 157, 168, 78, 94, 242, 219, 103, 9, 35, 221, 229, 128, 236, 200, 83, 42, 175, 36, 181, 118, 208, 68, 254, 101, 143, 189, 124, 201, 170, 21, 239, 241, 214, 151, 16, 174, 195, 97, 33, 158, 74, 250, 97, 157, 47, 148, 224, 57, 27, 101 }, new byte[] { 202, 146, 90, 140, 93, 159, 113, 188, 65, 31, 119, 85, 236, 183, 112, 198, 4, 197, 22, 86, 96, 123, 72, 60, 11, 154, 49, 94, 208, 223, 35, 242, 215, 232, 208, 63, 72, 249, 83, 44, 124, 20, 27, 124, 74, 84, 170, 26, 130, 254, 199, 105, 51, 168, 63, 112, 108, 189, 48, 134, 56, 58, 107, 192, 141, 14, 111, 187, 128, 243, 246, 118, 13, 102, 157, 49, 126, 15, 50, 228, 220, 110, 254, 131, 96, 182, 230, 54, 46, 217, 180, 167, 179, 9, 118, 81, 54, 68, 205, 229, 189, 39, 192, 251, 178, 36, 15, 8, 64, 24, 47, 201, 41, 110, 120, 155, 1, 16, 249, 210, 124, 140, 55, 219, 3, 73, 149, 186 }, "hakan" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_cartID",
                table: "CartItems",
                column: "cartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_productID",
                table: "CartItems",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryID",
                table: "Products",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerLists_productID",
                table: "SellerLists",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "SellerLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
