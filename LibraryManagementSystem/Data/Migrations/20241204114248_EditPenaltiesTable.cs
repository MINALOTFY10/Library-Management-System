using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditPenaltiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "910cfd5b-ae4b-4f74-bc39-1d8fc6d6355d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad00738e-4f6f-4ec3-adee-2ece08f2f33a");

            migrationBuilder.AlterColumn<int>(
                name: "PenaltyType",
                table: "Penalties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c66657b-eff4-42ac-8e8c-998a337c7c72", null, "Client", "client" },
                    { "ab2bf2bf-e8b4-48a7-b899-f8b5da5b4ce1", null, "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c66657b-eff4-42ac-8e8c-998a337c7c72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab2bf2bf-e8b4-48a7-b899-f8b5da5b4ce1");

            migrationBuilder.AlterColumn<string>(
                name: "PenaltyType",
                table: "Penalties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "910cfd5b-ae4b-4f74-bc39-1d8fc6d6355d", null, "Admin", "admin" },
                    { "ad00738e-4f6f-4ec3-adee-2ece08f2f33a", null, "Client", "client" }
                });
        }
    }
}
