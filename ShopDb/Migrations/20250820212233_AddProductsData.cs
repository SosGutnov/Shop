using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopDb.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("2f62ae97-69db-4cfa-9094-a68398360bd5"), 10m, "Desc1", "/images/jinx.png", "Name" },
                    { new Guid("7d49957c-b2a2-442d-93e0-706467f5ac4f"), 10m, "Desc1", "/images/jinx.png", "Name" },
                    { new Guid("a5c9c924-db14-4677-bd38-211ae80a01c1"), 10m, "Desc1", "/images/jinx.png", "Name" },
                    { new Guid("e7d0492a-b54e-4bc8-9e0c-5b3d119e28f7"), 10m, "Desc1", "/images/jinx.png", "Name" },
                    { new Guid("ea17a73a-5300-45a7-8a4e-3ab7e63b8a5b"), 10m, "Desc1", "/images/jinx.png", "Name" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f62ae97-69db-4cfa-9094-a68398360bd5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d49957c-b2a2-442d-93e0-706467f5ac4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a5c9c924-db14-4677-bd38-211ae80a01c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7d0492a-b54e-4bc8-9e0c-5b3d119e28f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea17a73a-5300-45a7-8a4e-3ab7e63b8a5b"));
        }
    }
}
