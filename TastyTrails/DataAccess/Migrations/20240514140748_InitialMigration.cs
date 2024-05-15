using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ammount = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_FoodItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "City", "Country", "Currency", "Description", "Name", "WorkingHours" },
                values: new object[,]
                {
                    { 1, "Addr1", "Novi Sad", "Serbia", "RSD", "Resraurant One", "Restaurant_One", null },
                    { 2, "Addr2", "Belgrade", "Serbia", "RSD", "Resraurant Two", "Restaurant_Two", null },
                    { 3, "Addr3", "Novi Sad", "Serbia", "RSD", "Resraurant Three", "Restaurant_Three", null }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Addr1", "user1@test.com", "John", "Doe", "12345" },
                    { 2, "Addr2", "user2@test.com", "Sara", "Sara", "52678" },
                    { 3, "Addr2", "user2@test.com", "Jack", "Jack", "54954" }
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Pasta with white sauce, basil and parmesan", "Pasta Carbonara", 15m, 1 },
                    { 2, "Pasta with pesto sauce, basil and parmesan", "Pasta Pesto", 11m, 2 },
                    { 3, "Beef burger", "Clasic Burger", 30m, 3 },
                    { 4, "Salad with chicken", "Chicken Salad", 12m, 3 },
                    { 5, "Green Salad", "Green Salad", 10m, 2 },
                    { 6, "Pancakes with nutela", "Pancakes", 7m, 1 },
                    { 7, "Burger with chedar cheese", "CheeseBurger", 27m, 1 },
                    { 8, "Burger with bacon", "Bacon Burger", 35m, 2 },
                    { 9, "Chips", "Chips", 5m, 3 },
                    { 10, "Vege burge", "Vege Burger", 30m, 3 },
                    { 11, "Pizza Cappricciosa", "Pizza Cappricciosa", 21m, 2 },
                    { 12, "Pizza with cheese", "Pizza Margherita", 23m, 1 },
                    { 13, "Pizza with olives", "Pizza Venezia", 25m, 1 },
                    { 14, "Pizza with chicken meat", "Pizza Chicken", 19m, 1 },
                    { 15, "4 types of cheese", "Pizza Quttro formaggi", 20m, 3 },
                    { 16, "Pasta, Bolognese sauce, basil, parmesan", "Pasta Bolognese", 12m, 3 },
                    { 17, "Pasta, sauce, basil, parmesan", "Pasta Napolitana", 18m, 2 },
                    { 18, "Pasta, sauce, basil, parmesan", "Pasta Arrabbiata", 24m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_RestaurantId",
                table: "FoodItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_MenuItemId",
                table: "OrderMenuItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_OrderId",
                table: "OrderMenuItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserInfoId",
                table: "Orders",
                column: "UserInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderMenuItems");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
