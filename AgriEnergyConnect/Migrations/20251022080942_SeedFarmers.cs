using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgriEnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class SeedFarmers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Pretoria", "Xikombiso Dlamini" },
                    { 2, "Johannesburg", "Rihlatlho Mavhungu" },
                    { 3, "Nelspruit", "Tiyani Phiri" },
                    { 4, "Polokwane", "Lufuno Shongwe" },
                    { 5, "Soweto", "Nyiko Tshabalala" },
                    { 6, "Tzaneen", "Rendani Mokoena" },
                    { 7, "Mbombela", "Khensani Ndlovu" },
                    { 8, "Thohoyandou", "Tsakani Hlabangana" },
                    { 9, "Polokwane", "Vutomi Ramabulana" },
                    { 10, "Pretoria", "Mandla Maphosa" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "FarmerId", "Name", "ProductionDate" },
                values: new object[,]
                {
                    { 1, "Grain", 1, "Corn", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1488) },
                    { 2, "Vegetable", 1, "Pumpkin", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1561) },
                    { 3, "Grain", 2, "Sorghum", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1564) },
                    { 4, "Vegetable", 2, "Tomato", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1565) },
                    { 5, "Legume", 3, "Peanuts", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1567) },
                    { 6, "Vegetable", 3, "Spinach", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1569) },
                    { 7, "Grain", 4, "Maize", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1571) },
                    { 8, "Vegetable", 4, "Cabbage", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1573) },
                    { 9, "Legume", 5, "Soy", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1575) },
                    { 10, "Vegetable", 5, "Carrot", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1577) },
                    { 11, "Grain", 6, "Wheat", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1579) },
                    { 12, "Vegetable", 6, "Beetroot", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1580) },
                    { 13, "Grain", 7, "Barley", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1582) },
                    { 14, "Vegetable", 7, "Chili", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1586) },
                    { 15, "Grain", 8, "Millet", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1587) },
                    { 16, "Vegetable", 8, "Onion", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1589) },
                    { 17, "Legume", 9, "Cowpeas", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1590) },
                    { 18, "Vegetable", 9, "Lettuce", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1592) },
                    { 19, "Legume", 10, "Chickpeas", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1594) },
                    { 20, "Vegetable", 10, "Cucumber", new DateTime(2025, 10, 22, 8, 9, 42, 116, DateTimeKind.Utc).AddTicks(1595) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
