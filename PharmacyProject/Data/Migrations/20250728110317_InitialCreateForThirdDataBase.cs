using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateForThirdDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pharmacies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pharmacies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Medicines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1950f458-52f7-4acb-a786-9bd3220f3c88", "AQAAAAIAAYagAAAAEMP/bgcymA3u7eCApmqjoTXRIgIskM+TOKdKri+SvhTRk3XOr2dx/nr9O9ofrFo0xQ==", "e272a7f8-a41e-43d2-a592-4c20b89a11e0" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExperationDate", "UserId" },
                values: new object[] { new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExperationDate", "UserId" },
                values: new object[] { new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExperationDate", "UserId" },
                values: new object[] { new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" });

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsDeleted", "UserId" },
                values: new object[] { false, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" });

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsDeleted", "UserId" },
                values: new object[] { false, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" });

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsDeleted", "UserId" },
                values: new object[] { false, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_UserId",
                table: "Pharmacies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UserId",
                table: "Medicines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_AspNetUsers_UserId",
                table: "Medicines",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_AspNetUsers_UserId",
                table: "Pharmacies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_AspNetUsers_UserId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_AspNetUsers_UserId",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_UserId",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_UserId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Medicines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "026c1164-345c-48df-a8c2-6d78a945ec02", "AQAAAAIAAYagAAAAEGRmBEGLqCMnBPxPXw1bjhg+6My42VU2vbV2Vn4p2y7ceb3MzpSfFw4edTWSkAU+ag==", "e67d8085-44bb-49ce-aaa2-b37906aae577" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExperationDate",
                value: new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExperationDate",
                value: new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExperationDate",
                value: new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
