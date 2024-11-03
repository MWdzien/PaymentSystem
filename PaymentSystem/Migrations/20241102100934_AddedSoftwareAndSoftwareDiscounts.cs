using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaymentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftwareAndSoftwareDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SoftwareDiscount",
                columns: new[] { "SoftwareDiscountId", "DateFrom", "DateTo", "DiscountName", "DiscountRate", "SoftwareId" },
                values: new object[,]
                {
                    { 101, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), "Black Friday Sale", 10m, 1 },
                    { 102, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), "Spring Promotion", 15m, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Softwares",
                keyColumn: "SoftwareId",
                keyValue: 1,
                columns: new[] { "Category", "CurrentVersion", "Description", "Name", "Price" },
                values: new object[] { "Graphics", "3.2.1", "Advanced photo editing software with AI features.", "PhotoEditor Pro", 500.00m });

            migrationBuilder.InsertData(
                table: "Softwares",
                columns: new[] { "SoftwareId", "Category", "CurrentVersion", "Description", "Name", "Price" },
                values: new object[] { 2, "Development", "2.5.0", "Integrated Development Environment for professional developers.", "CodeMaster IDE", 1000.00m });

            migrationBuilder.InsertData(
                table: "SoftwareDiscount",
                columns: new[] { "SoftwareDiscountId", "DateFrom", "DateTo", "DiscountName", "DiscountRate", "SoftwareId" },
                values: new object[] { 201, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), "Summer Discount", 12m, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SoftwareDiscount",
                keyColumn: "SoftwareDiscountId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SoftwareDiscount",
                keyColumn: "SoftwareDiscountId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "SoftwareDiscount",
                keyColumn: "SoftwareDiscountId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Softwares",
                keyColumn: "SoftwareId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Softwares",
                keyColumn: "SoftwareId",
                keyValue: 1,
                columns: new[] { "Category", "CurrentVersion", "Description", "Name", "Price" },
                values: new object[] { "Business", "1.0", "Description descriptiopn descritortopn", "Software1", 10000m });
        }
    }
}
