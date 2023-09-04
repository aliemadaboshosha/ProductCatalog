using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace a_product_catalog.Migrations
{
    /// <inheritdoc />
    public partial class UsersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fc475a1-1db9-416c-90c9-0dea09f893c7", "0e974279-21c2-45d4-ba6d-291939038eec", "StockWorker", "worker" },
                    { "3803e632-e024-4b93-8ee7-5910cb88fef1", "a2802112-cb3d-409c-bc36-1da6878af20e", "NormalUser", "User" },
                    { "bfe5cf7b-4f1f-4fab-a6e9-82496c0bac6f", "e9915b1c-3eb6-4031-9464-23b684b2d958", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc475a1-1db9-416c-90c9-0dea09f893c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3803e632-e024-4b93-8ee7-5910cb88fef1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfe5cf7b-4f1f-4fab-a6e9-82496c0bac6f");
        }
    }
}
