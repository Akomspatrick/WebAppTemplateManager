using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentBasePaths",
                columns: table => new
                {
                    DocumentBasePathId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentBasePaths", x => x.DocumentBasePathId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelTypes",
                columns: table => new
                {
                    ModelTypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTypes", x => x.ModelTypeName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShellMaterials",
                columns: table => new
                {
                    ShellMaterialName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alloy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShellMaterials", x => x.ShellMaterialName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestFlowTypes",
                columns: table => new
                {
                    TestingModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TestingMode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestFlowTypes", x => x.TestingModeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelTypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelName);
                    table.ForeignKey(
                        name: "FK_Models_ModelTypes_ModelTypeName",
                        column: x => x.ModelTypeName,
                        principalTable: "ModelTypes",
                        principalColumn: "ModelTypeName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelVersions",
                columns: table => new
                {
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultTestingMode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    NominalOutput = table.Column<double>(type: "double", nullable: false),
                    NominalOutputPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NonlinearityPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MinimumDeadLoad = table.Column<int>(type: "int", nullable: false),
                    vMin = table.Column<double>(type: "double", nullable: false),
                    nMax = table.Column<int>(type: "int", nullable: false),
                    SafeLoad = table.Column<int>(type: "int", nullable: false),
                    UltimateLoad = table.Column<int>(type: "int", nullable: false),
                    ShellMaterialName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alloy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DefaultCableLength = table.Column<int>(type: "int", nullable: false),
                    NumberOfGauges = table.Column<int>(type: "int", nullable: false),
                    Resistance = table.Column<int>(type: "int", nullable: false),
                    CCNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Class = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Application = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TemperingHardnessLow = table.Column<int>(type: "int", nullable: false),
                    TemperingHardnessHigh = table.Column<int>(type: "int", nullable: false),
                    NTEPCertificationId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NTEPCertificationTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OIMLCertificationId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OIMLCertificationTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TestPointDirection = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVersions", x => new { x.ModelName, x.ModelVersionId });
                    table.UniqueConstraint("AK_ModelVersions_ModelName_ModelVersionId_Capacity", x => new { x.ModelName, x.ModelVersionId, x.Capacity });
                    table.ForeignKey(
                        name: "FK_ModelVersions_Models_ModelName",
                        column: x => x.ModelName,
                        principalTable: "Models",
                        principalColumn: "ModelName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelVersions_ShellMaterials_ShellMaterialName",
                        column: x => x.ShellMaterialName,
                        principalTable: "ShellMaterials",
                        principalColumn: "ShellMaterialName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ContentPDFPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangeOrderPDFPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentBasePathId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => new { x.DocumentName, x.ModelName, x.ModelVersionId });
                    table.ForeignKey(
                        name: "FK_Documents_ModelVersions_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersions",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Stage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubStage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InvoiceId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalesOrderId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CableLength = table.Column<int>(type: "int", nullable: false),
                    InspectionResult = table.Column<int>(type: "int", nullable: false),
                    DefaultTestingMode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsedCalibrationMode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThermexPurcharseOrderNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MachiningPurcharseOrderNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SteelPurcharseOrderNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BatcNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ModelVersions_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersions",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestPoints",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TestPointId = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPoints", x => new { x.ModelName, x.ModelVersionId, x.Capacity, x.TestPointId });
                    table.ForeignKey(
                        name: "FK_TestPoints_ModelVersions_ModelName_ModelVersionId_Capacity",
                        columns: x => new { x.ModelName, x.ModelVersionId, x.Capacity },
                        principalTable: "ModelVersions",
                        principalColumns: new[] { "ModelName", "ModelVersionId", "Capacity" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentDocumentTypes",
                columns: table => new
                {
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeName = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDocumentTypes", x => new { x.DocumentName, x.ModelName, x.ModelVersionId, x.DocumentTypeName });
                    table.ForeignKey(
                        name: "FK_DocumentDocumentTypes_DocumentTypes_DocumentTypeName",
                        column: x => x.DocumentTypeName,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDocumentTypes_Documents_DocumentName_ModelName_Model~",
                        columns: x => new { x.DocumentName, x.ModelName, x.ModelVersionId },
                        principalTable: "Documents",
                        principalColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeName", "GuidId" },
                values: new object[,]
                {
                    { "Cabling", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Chroming", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Gauging", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Sealing", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Wiring", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
                });

            migrationBuilder.InsertData(
                table: "ModelTypes",
                columns: new[] { "ModelTypeName", "GuidId" },
                values: new object[,]
                {
                    { "FIRSTMODELTYPE", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "SECONDMODELTYPE", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b") },
                    { "THIRDMODELTYPE", new Guid("3c69923e-a68e-4348-b06c-7007f527355d") }
                });

            migrationBuilder.InsertData(
                table: "ShellMaterials",
                columns: new[] { "ShellMaterialName", "Alloy", "GuidId" },
                values: new object[,]
                {
                    { "ShellMaterial1", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial2", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial3", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial4", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
                });

            migrationBuilder.InsertData(
                table: "TestFlowTypes",
                columns: new[] { "TestingModeId", "Description", "GuidId", "TestingMode" },
                values: new object[,]
                {
                    { 1, "FLOW TYPES FOR LOADCELL", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "AUTOMATIC" },
                    { 2, "FLOW TYPES FOR TESTLINKS", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "MANUAL" },
                    { 3, "FLOW TYPES FOR SCALES/PAD", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "SCALES/PAD" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelName", "GuidId", "ModelTypeName" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELTYPE" },
                    { "SECONDMODELNAME", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELTYPE" },
                    { "THIRDMODELNAME", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "SECONDMODELTYPE" }
                });

            migrationBuilder.InsertData(
                table: "ModelVersions",
                columns: new[] { "ModelName", "ModelVersionId", "Alloy", "Application", "CCNumber", "Capacity", "Class", "DefaultCableLength", "DefaultTestingMode", "GuidId", "MinimumDeadLoad", "ModelVersionName", "NTEPCertificationId", "NTEPCertificationTimestamp", "NominalOutput", "NominalOutputPercentage", "NonlinearityPercentage", "NumberOfGauges", "OIMLCertificationId", "OIMLCertificationTimestamp", "Resistance", "SafeLoad", "ShellMaterialName", "TemperingHardnessHigh", "TemperingHardnessLow", "TestPointDirection", "Timestamp", "UltimateLoad", "UserName", "VersionDescription", "nMax", "vMin" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", 1, true, "APPLICATION", "CCNUMBER", 100, "CLASS", 20, "AUTOMATIC", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), 1, "FIRST_VERSION_FIRSTMODEL_NAME", "NTEPCERTIFICATIONID", new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5061), 1.0, 1m, 1m, 1, "OIMLCERTIFICATIONID1", new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5062), 1, 1, "SHELLMATERIAL1", 1, 1, true, new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5060), 1, "OLADEJI", "SPECIAL DESIGN", 1, 1.0 },
                    { "FIRSTMODELNAME", 2, true, "APPLICATION", "CCNUMBER", 100, "CLASS", 20, "MANUAL", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), 2, "SECOND_VERSION_FIRSTMODELNAME", "NTEPCERTIFICATIONID", new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5082), 2.0, 2m, 2m, 2, "OIMLCERTIFICATIONID1", new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5082), 2, 2, "SHELLMATERIAL1", 2, 2, true, new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5079), 2, "OLADEJI", "AUTO DESIGN TO COMBAT SPLIILING", 2, 2.0 },
                    { "SECONDMODELNAME", 1, true, "APPLICATION", "CCNUMBER", 100, "CLASS", 20, "GETVALUESFROMTESTINGFLOWTYPES", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), 1, "FIRST_VERSION_SECONDMODELNAME", "NTEPCERTIFICATIONID", new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5086), 1.0, 1m, 1m, 1, "OIMLCERTIFICATIONID1", new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5086), 1, 1, "SHELLMATERIAL1", 1, 1, true, new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5086), 1, "OLADEJI", "INITIAL DESIGN", 1, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentName", "ModelName", "ModelVersionId", "ChangeOrderPDFPath", "ContentPDFPath", "DocumentBasePathId", "DocumentDescription", "GuidId", "Timestamp" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5385) },
                    { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5397) },
                    { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5400) },
                    { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5402) }
                });

            migrationBuilder.InsertData(
                table: "TestPoints",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId", "TestPointId", "GuidId" },
                values: new object[,]
                {
                    { 100, "FIRSTMODELNAME", 1, 2000, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 100, "FIRSTMODELNAME", 1, 3000, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 100, "FIRSTMODELNAME", 1, 4000, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 100, "FIRSTMODELNAME", 1, 10000, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 100, "SECONDMODELNAME", 1, 49, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
                });

            migrationBuilder.InsertData(
                table: "DocumentDocumentTypes",
                columns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId", "GuidId" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc A", "Cabling", "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "FIRSTMODELNAME ver1 DOc A", "Chroming", "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "FIRSTMODELNAME ver1 DOc A", "Sealing", "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "FIRSTMODELNAME ver1 DOc B", "Cabling", "FIRSTMODELNAME", 1, new Guid("7808711f-544a-423d-8d99-f00c31e35be5") },
                    { "FIRSTMODELNAME ver1 DOc B", "Chroming", "FIRSTMODELNAME", 1, new Guid("7808711f-544a-423d-8d99-f00c31e35be5") },
                    { "FIRSTMODELNAME ver1 DOc B", "Sealing", "FIRSTMODELNAME", 1, new Guid("7808711f-544a-423d-8d99-f00c31e35be5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDocumentTypes_DocumentTypeName",
                table: "DocumentDocumentTypes",
                column: "DocumentTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ModelName_ModelVersionId",
                table: "Documents",
                columns: new[] { "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelTypeName",
                table: "Models",
                column: "ModelTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_ModelVersions_ShellMaterialName",
                table: "ModelVersions",
                column: "ShellMaterialName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelName_ModelVersionId",
                table: "Products",
                columns: new[] { "ModelName", "ModelVersionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentBasePaths");

            migrationBuilder.DropTable(
                name: "DocumentDocumentTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TestFlowTypes");

            migrationBuilder.DropTable(
                name: "TestPoints");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "ModelVersions");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ShellMaterials");

            migrationBuilder.DropTable(
                name: "ModelTypes");
        }
    }
}
