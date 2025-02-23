using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrecisionFarming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropVarieties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropVarieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropVarieties_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Boundary = table.Column<Polygon>(type: "geography", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldsCrops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CropVarietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SowingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Yield = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldsCrops_CropVarieties_CropVarietyId",
                        column: x => x.CropVarietyId,
                        principalTable: "CropVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldsCrops_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crops",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2db4ee88-2bed-4e64-a95d-0cf667f67370"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4897), "Barley", null },
                    { new Guid("70916e69-1003-4efb-ac4e-5263dd3ff0c7"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4987), "Peas", null },
                    { new Guid("7e3a5f05-5c67-4a77-afaa-c1449eeb6693"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4729), "Alfalfa", null },
                    { new Guid("a31b7081-ca69-4548-a614-c9afa1ea0197"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4970), "Oats", null },
                    { new Guid("a936c5d8-2dd2-41e7-b071-68b78c5a48d0"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4951), "Fababean", null },
                    { new Guid("c7961535-9d7b-433d-9f4f-a458c7c6a3b6"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(5002), "Soybeans", null },
                    { new Guid("ca2e08ef-05c4-4855-a3a6-ee40e0ad77ff"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(5021), "Wheat", null },
                    { new Guid("f25a2358-8b43-4a16-8379-8b0313179ec9"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4934), "Corn", null },
                    { new Guid("f29bf920-7509-4fef-84cf-5c0f35617035"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4918), "Canola", null }
                });

            migrationBuilder.InsertData(
                table: "CropVarieties",
                columns: new[] { "Id", "CreatedAt", "CropId", "Description", "Distributor", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09bdf5e3-040c-4e8e-abc4-e47a2e418d08"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6445), new Guid("ca2e08ef-05c4-4855-a3a6-ee40e0ad77ff"), "Very high yields. Midge tolerance", "Nutrien Ag Solutions", "AAC Camrose VB", null },
                    { new Guid("1297b0be-a6ef-4670-a9b1-bec0007e9ab0"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6405), new Guid("70916e69-1003-4efb-ac4e-5263dd3ff0c7"), "High yield potential with earlier maturity. Very high protein content", "CANTERRA SEEDS", "CS ProStar Yellow", null },
                    { new Guid("29d51eb2-6de5-49e1-8d8b-4bf87cd6a582"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6351), new Guid("f29bf920-7509-4fef-84cf-5c0f35617035"), "Introducing InVigor L330PC an early maturing hybrid with excellent yield potential and strong standability. Coupled with our patented Pod Shatter Reduction technology, first generation clubroot resistance, strong standability, and the yield potential to exceed InVigor L233P all give InVigor L330PC potential across all growing zones.", "BASF/Invigor", "InVigor L330PC Hybrid", null },
                    { new Guid("d1337a54-fdde-4e50-aca3-6f682a8c497f"), new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6258), new Guid("2db4ee88-2bed-4e64-a95d-0cf667f67370"), "Very high yield potential. Shorter than CDC Austenson with strong straw and excellent standability. Higher test weight and increased plumpness.", "CANTERRA SEEDS LTD", "AAC Lariat Feed 2-Row", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropVarieties_CropId",
                table: "CropVarieties",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FarmId",
                table: "Fields",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsCrops_CropVarietyId",
                table: "FieldsCrops",
                column: "CropVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsCrops_FieldId",
                table: "FieldsCrops",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldsCrops");

            migrationBuilder.DropTable(
                name: "CropVarieties");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Farms");
        }
    }
}
