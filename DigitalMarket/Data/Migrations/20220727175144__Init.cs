using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMarket.Migrations
{
    public partial class _Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Category", "Description", "Price", "ProductName", "Seller" },
                values: new object[] { 2, "Games", "Кооперативная многопользовательская компьютерная игра в жанре приключенческого боевика с пиратской тематикой, разработанная компанией Rare и издаваемая Microsoft Studios.", 700m, "Sea of Thieves", "Rare Studio" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Category", "Description", "Price", "ProductName", "Seller" },
                values: new object[] { 3, "Games", "Мультиплатформенная компьютерная игра в жанре action-adventure с открытым миром", 700m, "Grand Theft Auto 5", "Rockstar North" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Category", "Description", "Price", "ProductName", "Seller" },
                values: new object[] { 4, "Games", "Компьютерная игра в жанре action-adventure, разработанная студией Rockstar North", 250m, "Grand Theft Auto: San Andreas", "Rockstar North" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);
        }
    }
}
