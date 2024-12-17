using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditPenaltiesTableID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c66657b-eff4-42ac-8e8c-998a337c7c72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab2bf2bf-e8b4-48a7-b899-f8b5da5b4ce1");

            migrationBuilder.DropColumn(
                name: "CopyId",
                table: "Penalties");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7850a7e8-0375-4e66-926e-b424b20432c3", null, "Client", "client" },
                    { "ada6163a-59fa-47ae-aebf-33a3e7948ddd", null, "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7850a7e8-0375-4e66-926e-b424b20432c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada6163a-59fa-47ae-aebf-33a3e7948ddd");

            migrationBuilder.AddColumn<int>(
                name: "CopyId",
                table: "Penalties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c66657b-eff4-42ac-8e8c-998a337c7c72", null, "Client", "client" },
                    { "ab2bf2bf-e8b4-48a7-b899-f8b5da5b4ce1", null, "Admin", "admin" }
                });
        }
    }
}
