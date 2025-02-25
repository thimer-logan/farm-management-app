using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecisionFarming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccessType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmAccesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmAccesses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmAccesses_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("09bdf5e3-040c-4e8e-abc4-e47a2e418d08"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("1297b0be-a6ef-4670-a9b1-bec0007e9ab0"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("29d51eb2-6de5-49e1-8d8b-4bf87cd6a582"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("d1337a54-fdde-4e50-aca3-6f682a8c497f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("2db4ee88-2bed-4e64-a95d-0cf667f67370"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("70916e69-1003-4efb-ac4e-5263dd3ff0c7"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("7e3a5f05-5c67-4a77-afaa-c1449eeb6693"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("a31b7081-ca69-4548-a614-c9afa1ea0197"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("a936c5d8-2dd2-41e7-b071-68b78c5a48d0"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("c7961535-9d7b-433d-9f4f-a458c7c6a3b6"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("ca2e08ef-05c4-4855-a3a6-ee40e0ad77ff"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("f25a2358-8b43-4a16-8379-8b0313179ec9"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("f29bf920-7509-4fef-84cf-5c0f35617035"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 14, 3, 46, 352, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.CreateIndex(
                name: "IX_FarmAccesses_FarmId",
                table: "FarmAccesses",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmAccesses_UserId",
                table: "FarmAccesses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmAccesses");

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("09bdf5e3-040c-4e8e-abc4-e47a2e418d08"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("1297b0be-a6ef-4670-a9b1-bec0007e9ab0"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("29d51eb2-6de5-49e1-8d8b-4bf87cd6a582"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "CropVarieties",
                keyColumn: "Id",
                keyValue: new Guid("d1337a54-fdde-4e50-aca3-6f682a8c497f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("2db4ee88-2bed-4e64-a95d-0cf667f67370"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("70916e69-1003-4efb-ac4e-5263dd3ff0c7"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("7e3a5f05-5c67-4a77-afaa-c1449eeb6693"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("a31b7081-ca69-4548-a614-c9afa1ea0197"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("a936c5d8-2dd2-41e7-b071-68b78c5a48d0"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("c7961535-9d7b-433d-9f4f-a458c7c6a3b6"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("ca2e08ef-05c4-4855-a3a6-ee40e0ad77ff"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("f25a2358-8b43-4a16-8379-8b0313179ec9"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Crops",
                keyColumn: "Id",
                keyValue: new Guid("f29bf920-7509-4fef-84cf-5c0f35617035"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4918));
        }
    }
}
