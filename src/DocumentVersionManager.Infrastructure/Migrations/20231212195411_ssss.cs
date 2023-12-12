using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentBasePath",
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
                    table.PrimaryKey("PK_DocumentBasePath", x => x.DocumentBasePathId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocumentTypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocumentTypeName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelType",
                columns: table => new
                {
                    ModelTypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelType", x => x.ModelTypeName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShellMaterial",
                columns: table => new
                {
                    ShellMaterialName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alloy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShellMaterial", x => x.ShellMaterialName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelTypesName = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelName);
                    table.ForeignKey(
                        name: "FK_Models_ModelType_ModelTypesName",
                        column: x => x.ModelTypesName,
                        principalTable: "ModelType",
                        principalColumn: "ModelTypeName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelVersion",
                columns: table => new
                {
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TestingModeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVersion", x => new { x.ModelName, x.ModelVersionId });
                    table.ForeignKey(
                        name: "FK_ModelVersion_Models_ModelName",
                        column: x => x.ModelName,
                        principalTable: "Models",
                        principalColumn: "ModelName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Document",
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
                    table.PrimaryKey("PK_Document", x => new { x.DocumentName, x.ModelName, x.ModelVersionId });
                    table.ForeignKey(
                        name: "FK_Document_ModelVersion_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersion",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
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
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ModelVersion_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersion",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => new { x.Capacity, x.ModelName, x.ModelVersionId });
                    table.ForeignKey(
                        name: "FK_Specification_ModelVersion_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersion",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specification_ShellMaterial_ShellMaterialName",
                        column: x => x.ShellMaterialName,
                        principalTable: "ShellMaterial",
                        principalColumn: "ShellMaterialName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentDocumentType",
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
                    table.PrimaryKey("PK_DocumentDocumentType", x => new { x.DocumentName, x.ModelName, x.ModelVersionId, x.DocumentTypeName });
                    table.ForeignKey(
                        name: "FK_DocumentDocumentType_DocumentType_DocumentTypeName",
                        column: x => x.DocumentTypeName,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDocumentType_Document_DocumentName_ModelName_ModelVe~",
                        columns: x => new { x.DocumentName, x.ModelName, x.ModelVersionId },
                        principalTable: "Document",
                        principalColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CapacityTestPoint",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TestPoint = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityTestPoint", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_CapacityTestPoint_Specification_Capacity_ModelName_ModelVers~",
                        columns: x => new { x.Capacity, x.ModelName, x.ModelVersionId },
                        principalTable: "Specification",
                        principalColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DocumentType",
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
                table: "ModelType",
                columns: new[] { "ModelTypeName", "GuidId" },
                values: new object[,]
                {
                    { "FIRSTMODELTYPE", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "SECONDMODELTYPE", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b") },
                    { "THIRDMODELTYPE", new Guid("3c69923e-a68e-4348-b06c-7007f527355d") }
                });

            migrationBuilder.InsertData(
                table: "ShellMaterial",
                columns: new[] { "ShellMaterialName", "Alloy", "GuidId" },
                values: new object[,]
                {
                    { "ShellMaterial1", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial2", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial3", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial4", true, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelName", "GuidId", "ModelTypesName" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELTYPE" },
                    { "SECONDMODELNAME", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELTYPE" },
                    { "THIRDMODELNAME", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "SECONDMODELTYPE" }
                });

            migrationBuilder.InsertData(
                table: "ModelVersion",
                columns: new[] { "ModelName", "ModelVersionId", "GuidId", "ModelVersionName", "TestingModeName", "Timestamp", "UserName", "VersionDescription" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRST_VERSION_FIRSTMODEL_NAME", "", new DateTime(2023, 12, 12, 19, 54, 11, 97, DateTimeKind.Utc).AddTicks(342), "OLADEJI", "SPECIAL DESIGN" },
                    { "FIRSTMODELNAME", 2, new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "SECOND_VERSION_FIRSTMODELNAME", "", new DateTime(2023, 12, 12, 19, 54, 11, 97, DateTimeKind.Utc).AddTicks(355), "OLADEJI", "AUTO DESIGN TO COMBAT SPLIILING" },
                    { "SECONDMODELNAME", 1, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRST_VERSION_SECONDMODELNAME", "", new DateTime(2023, 12, 12, 19, 54, 11, 97, DateTimeKind.Utc).AddTicks(358), "OLADEJI", "INITIAL DESIGN" }
                });

            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "DocumentName", "ModelName", "ModelVersionId", "ChangeOrderPDFPath", "ContentPDFPath", "DocumentBasePathId", "DocumentDescription", "GuidId", "Timestamp" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 12, 12, 19, 54, 11, 92, DateTimeKind.Utc).AddTicks(4475) },
                    { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 12, 12, 19, 54, 11, 92, DateTimeKind.Utc).AddTicks(4488) },
                    { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), new DateTime(2023, 12, 12, 19, 54, 11, 92, DateTimeKind.Utc).AddTicks(4496) },
                    { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2, "CHANGE ORDER PATH", "CONTENT PDF PATH", "001", "SIMPLE DESCRITION OF DOCUMENT", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), new DateTime(2023, 12, 12, 19, 54, 11, 92, DateTimeKind.Utc).AddTicks(4498) }
                });

            migrationBuilder.InsertData(
                table: "Specification",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId", "Alloy", "Application", "CCNumber", "Class", "DefaultCableLength", "GuidId", "MinimumDeadLoad", "NTEPCertificationId", "NTEPCertificationTimestamp", "NominalOutput", "NominalOutputPercentage", "NonlinearityPercentage", "NumberOfGauges", "OIMLCertificationId", "OIMLCertificationTimestamp", "Resistance", "SafeLoad", "ShellMaterialName", "TemperingHardnessHigh", "TemperingHardnessLow", "Timestamp", "UltimateLoad", "UserName", "nMax", "vMin" },
                values: new object[,]
                {
                    { 100, "FIRSTMODELNAME", 1, true, "APPLICATION", "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), 1, "NTEPCERTIFICATIONID", new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5863), 1.0, 1m, 1m, 1, "OIMLCERTIFICATIONID1", new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5864), 1, 1, "SHELLMATERIAL1", 1, 1, new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5861), 1, "OLADEJI", 1, 1.0 },
                    { 100, "FIRSTMODELNAME", 2, true, "APPLICATION", "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), 1, "NTEPCERTIFICATIONID", new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5881), 1.0, 1m, 1m, 1, "OIMLCERTIFICATIONID2", new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5881), 1, 1, "SHELLMATERIAL2", 1, 1, new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5880), 1, "OLADEJI", 1, 1.0 },
                    { 100, "SECONDMODELNAME", 1, true, "APPLICATION", "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), 1, "NTEPCERTIFICATIONID", new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5886), 1.0, 1m, 1m, 1, "OIMLCERTIFICATIONID3", new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5886), 1, 1, "SHELLMATERIAL3", 1, 1, new DateTime(2023, 12, 12, 19, 54, 11, 99, DateTimeKind.Utc).AddTicks(5886), 1, "OLADEJI", 1, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "CapacityTestPoint",
                columns: new[] { "TestId", "Capacity", "GuidId", "ModelName", "ModelVersionId", "TestPoint" },
                values: new object[,]
                {
                    { 1, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME", 1, 1 },
                    { 49, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "SECONDMODELNAME", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "DocumentDocumentType",
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
                name: "IX_CapacityTestPoint_Capacity_ModelName_ModelVersionId",
                table: "CapacityTestPoint",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Document_ModelName_ModelVersionId",
                table: "Document",
                columns: new[] { "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDocumentType_DocumentTypeName",
                table: "DocumentDocumentType",
                column: "DocumentTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelTypesName",
                table: "Models",
                column: "ModelTypesName");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ModelName_ModelVersionId",
                table: "Product",
                columns: new[] { "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Specification_ModelName_ModelVersionId",
                table: "Specification",
                columns: new[] { "ModelName", "ModelVersionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specification_ShellMaterialName",
                table: "Specification",
                column: "ShellMaterialName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacityTestPoint");

            migrationBuilder.DropTable(
                name: "DocumentBasePath");

            migrationBuilder.DropTable(
                name: "DocumentDocumentType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ShellMaterial");

            migrationBuilder.DropTable(
                name: "ModelVersion");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ModelType");
        }
    }
}
