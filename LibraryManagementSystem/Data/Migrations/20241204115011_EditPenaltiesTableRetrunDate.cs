using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditPenaltiesTableRetrunDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7850a7e8-0375-4e66-926e-b424b20432c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada6163a-59fa-47ae-aebf-33a3e7948ddd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Penalties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b303b17-79ba-417c-a758-8f8614aa6cae", null, "Client", "client" },
                    { "40b93e53-ddb1-4b59-a5a5-5c65a29497f0", null, "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b303b17-79ba-417c-a758-8f8614aa6cae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40b93e53-ddb1-4b59-a5a5-5c65a29497f0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Penalties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7850a7e8-0375-4e66-926e-b424b20432c3", null, "Client", "client" },
                    { "ada6163a-59fa-47ae-aebf-33a3e7948ddd", null, "Admin", "admin" }
                });
        }
    }
}
