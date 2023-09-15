using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapacityDocument",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "longtext", nullable: false),
                    DocumentPath = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityDocument", x => x.Capacity);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CapacitySpecification",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "longtext", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    NominalOutput = table.Column<double>(type: "double", nullable: true),
                    NominalOutputPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NonlinearityPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinimumDeadLoad = table.Column<int>(type: "int", nullable: true),
                    vMin = table.Column<double>(type: "double", nullable: true),
                    nMax = table.Column<int>(type: "int", nullable: true),
                    SafeLoad = table.Column<int>(type: "int", nullable: true),
                    UltimateLoad = table.Column<int>(type: "int", nullable: true),
                    ShellMaterial = table.Column<string>(type: "longtext", nullable: false),
                    Alloy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DefaultCableLength = table.Column<int>(type: "int", nullable: true),
                    TempRangeLow = table.Column<int>(type: "int", nullable: true),
                    TempRangeHigh = table.Column<int>(type: "int", nullable: true),
                    NumberOfGauges = table.Column<int>(type: "int", nullable: true),
                    Resistance = table.Column<int>(type: "int", nullable: true),
                    CCNumber = table.Column<string>(type: "longtext", nullable: false),
                    Class = table.Column<string>(type: "longtext", nullable: false),
                    Application = table.Column<string>(type: "longtext", nullable: false),
                    NumberInBasket = table.Column<int>(type: "int", nullable: true),
                    AustenitizationTemperatureInF = table.Column<double>(type: "double", nullable: true),
                    AustenitizationTimeInSeconds = table.Column<int>(type: "int", nullable: true),
                    AustenitizationHardnessLow = table.Column<int>(type: "int", nullable: true),
                    AustenitizationHardnessHigh = table.Column<int>(type: "int", nullable: true),
                    TemperingTemperatureInF = table.Column<double>(type: "double", nullable: true),
                    TemperingTimeInSeconds = table.Column<int>(type: "int", nullable: true),
                    TemperingHardnessLow = table.Column<int>(type: "int", nullable: true),
                    TemperingHardnessHigh = table.Column<int>(type: "int", nullable: true),
                    HasScrews = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NTEPCertificationId = table.Column<string>(type: "longtext", nullable: false),
                    NTEPCertificationTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OIMLCertificationId = table.Column<string>(type: "longtext", nullable: false),
                    OIMLCertificationTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitySpecification", x => x.Capacity);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacityDocument");

            migrationBuilder.DropTable(
                name: "CapacitySpecification");
        }
    }
}
