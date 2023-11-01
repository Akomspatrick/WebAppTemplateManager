using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TES4r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    TypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.TypeName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HigherModel",
                columns: table => new
                {
                    HigherModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    HigherModelDescription = table.Column<string>(type: "longtext", nullable: false),
                    ProductId = table.Column<string>(type: "longtext", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherModel", x => x.HigherModelName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelType",
                columns: table => new
                {
                    ModelTypesName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelType", x => x.ModelTypesName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShellMaterial",
                columns: table => new
                {
                    ShellMaterialName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Alloy = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShellMaterial", x => x.ShellMaterialName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ModelTypesName = table.Column<string>(type: "varchar(128)", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelName);
                    table.ForeignKey(
                        name: "FK_Models_ModelType_ModelTypesName",
                        column: x => x.ModelTypesName,
                        principalTable: "ModelType",
                        principalColumn: "ModelTypesName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelVersion",
                columns: table => new
                {
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    VersionDescription = table.Column<string>(type: "longtext", nullable: false),
                    ModelVersionName = table.Column<string>(type: "longtext", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CapacitySpecification",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
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
                    ShellMaterialName = table.Column<string>(type: "varchar(255)", nullable: false),
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
                    OIMLCertificationTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitySpecification", x => new { x.Capacity, x.ModelName, x.ModelVersionId });
                    table.ForeignKey(
                        name: "FK_CapacitySpecification_ModelVersion_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersion",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacitySpecification_ShellMaterial_ShellMaterialName",
                        column: x => x.ShellMaterialName,
                        principalTable: "ShellMaterial",
                        principalColumn: "ShellMaterialName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ContentPDFPath = table.Column<string>(type: "longtext", nullable: false),
                    ChangeOrderPDFPath = table.Column<string>(type: "longtext", nullable: false),
                    DocumentDescription = table.Column<string>(type: "longtext", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CapacityTestPoint",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityTestPoint", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_CapacityTestPoint_CapacitySpecification_Capacity_ModelName_M~",
                        columns: x => new { x.Capacity, x.ModelName, x.ModelVersionId },
                        principalTable: "CapacitySpecification",
                        principalColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentDocumentType",
                columns: table => new
                {
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeName = table.Column<string>(type: "varchar(255)", nullable: false),
                    DocumentTypeTypeName = table.Column<string>(type: "varchar(128)", nullable: true),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDocumentType", x => new { x.DocumentName, x.ModelName, x.ModelVersionId, x.DocumentTypeName });
                    table.ForeignKey(
                        name: "FK_DocumentDocumentType_DocumentType_DocumentTypeTypeName",
                        column: x => x.DocumentTypeTypeName,
                        principalTable: "DocumentType",
                        principalColumn: "TypeName");
                    table.ForeignKey(
                        name: "FK_DocumentDocumentType_Document_DocumentName_ModelName_ModelVe~",
                        columns: x => new { x.DocumentName, x.ModelName, x.ModelVersionId },
                        principalTable: "Document",
                        principalColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "TypeName", "GuidId" },
                values: new object[,]
                {
                    { "Cabling", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Chroming", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Gauging", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Sealing", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "Wiring", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
                });

            migrationBuilder.InsertData(
                table: "HigherModel",
                columns: new[] { "HigherModelName", "Capacity", "GuidId", "HigherModelDescription", "Id", "ProductId" },
                values: new object[,]
                {
                    { "HigherModel1", 1, new Guid("00000000-0000-0000-0000-000000000000"), "HigherModel1", "e210a518-65eb-41d2-a1b4-d5a48c6f5eba", "HigherModel1" },
                    { "HigherModel2", 12, new Guid("00000000-0000-0000-0000-000000000000"), "HigherModel12", "bf84410a-b2b2-4aa8-b07e-e8cd16409437", "HigherModel12" },
                    { "HigherModel3", 13, new Guid("00000000-0000-0000-0000-000000000000"), "HigherModel1", "40037c58-2d3e-4337-b6f1-f8c9608649b3", "HigherModel13" },
                    { "HigherModel4", 14, new Guid("00000000-0000-0000-0000-000000000000"), "HigherModel14", "5b9e830b-9290-4d70-848a-a4020086049d", "HigherModel14" },
                    { "HigherModel5", 5, new Guid("00000000-0000-0000-0000-000000000000"), "HigherModel5", "37cd997d-1c2f-4b25-9743-83f0165f8474", "HigherModel5" }
                });

            migrationBuilder.InsertData(
                table: "ModelType",
                columns: new[] { "ModelTypesName", "GuidId" },
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
                    { "ShellMaterial1", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial2", 2, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial3", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "ShellMaterial4", 2, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
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
                columns: new[] { "ModelName", "ModelVersionId", "GuidId", "ModelVersionName", "Timestamp", "Username", "VersionDescription" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRST_VERSION_FIRSTMODEL_NAME", new DateTime(2023, 11, 1, 20, 4, 0, 949, DateTimeKind.Utc).AddTicks(4419), "OLADEJI", "SPECIAL DESIGN" },
                    { "FIRSTMODELNAME", 2, new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "SECOND_VERSION_FIRSTMODELNAME", new DateTime(2023, 11, 1, 20, 4, 0, 949, DateTimeKind.Utc).AddTicks(4428), "OLADEJI", "AUTO DESIGN TO COMBAT SPLIILING" },
                    { "SECONDMODELNAME", 1, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRST_VERSION_SECONDMODELNAME", new DateTime(2023, 11, 1, 20, 4, 0, 949, DateTimeKind.Utc).AddTicks(4430), "OLADEJI", "INITIAL DESIGN" }
                });

            migrationBuilder.InsertData(
                table: "CapacitySpecification",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId", "Alloy", "Application", "AustenitizationHardnessHigh", "AustenitizationHardnessLow", "AustenitizationTemperatureInF", "AustenitizationTimeInSeconds", "CCNumber", "Class", "DefaultCableLength", "GuidId", "HasScrews", "MinimumDeadLoad", "NTEPCertificationId", "NTEPCertificationTimestamp", "NominalOutput", "NominalOutputPercentage", "NonlinearityPercentage", "NumberInBasket", "NumberOfGauges", "OIMLCertificationId", "OIMLCertificationTimestamp", "Resistance", "SafeLoad", "ShellMaterialName", "TempRangeHigh", "TempRangeLow", "TemperingHardnessHigh", "TemperingHardnessLow", "TemperingTemperatureInF", "TemperingTimeInSeconds", "Timestamp", "UltimateLoad", "Username", "nMax", "vMin" },
                values: new object[,]
                {
                    { 100, "FIRSTMODELNAME", 1, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4194), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID1", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4196), 1, 1, "SHELLMATERIAL1", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4185), 1, "OLADEJI", 1, 1.0 },
                    { 100, "FIRSTMODELNAME", 2, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4229), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID2", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4229), 1, 1, "SHELLMATERIAL2", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4226), 1, "OLADEJI", 1, 1.0 },
                    { 100, "SECONDMODELNAME", 1, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4234), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID3", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4234), 1, 1, "SHELLMATERIAL3", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4232), 1, "OLADEJI", 1, 1.0 },
                    { 101, "FIRSTMODELNAME", 1, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4217), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID2", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4218), 1, 1, "SHELLMATERIAL2", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4215), 1, "OLADEJI", 1, 1.0 },
                    { 102, "FIRSTMODELNAME", 1, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", "CLASS", 20, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4223), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID2", new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4224), 1, 1, "SHELLMATERIAL2", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 11, 1, 20, 4, 0, 944, DateTimeKind.Utc).AddTicks(4221), 1, "OLADEJI", 1, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "DocumentName", "ModelName", "ModelVersionId", "ChangeOrderPDFPath", "ContentPDFPath", "DocumentDescription", "GuidId", "Timestamp" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 11, 1, 20, 4, 0, 945, DateTimeKind.Utc).AddTicks(9941) },
                    { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 11, 1, 20, 4, 0, 945, DateTimeKind.Utc).AddTicks(9952) },
                    { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), new DateTime(2023, 11, 1, 20, 4, 0, 945, DateTimeKind.Utc).AddTicks(9954) },
                    { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), new DateTime(2023, 11, 1, 20, 4, 0, 945, DateTimeKind.Utc).AddTicks(9956) }
                });

            migrationBuilder.InsertData(
                table: "CapacityTestPoint",
                columns: new[] { "TestId", "Capacity", "GuidId", "ModelName", "ModelVersionId", "Weight" },
                values: new object[,]
                {
                    { 1, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME", 1, 1 },
                    { 9, 101, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME", 1, 1 },
                    { 39, 102, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME", 1, 1 },
                    { 49, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "SECONDMODELNAME", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "DocumentDocumentType",
                columns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId", "DocumentTypeTypeName", "GuidId" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc A", "Cabling", "FIRSTMODELNAME", 1, null, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "FIRSTMODELNAME ver1 DOc A", "Chroming", "FIRSTMODELNAME", 1, null, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "FIRSTMODELNAME ver1 DOc A", "Sealing", "FIRSTMODELNAME", 1, null, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "FIRSTMODELNAME ver1 DOc B", "Cabling", "FIRSTMODELNAME", 1, null, new Guid("7808711f-544a-423d-8d99-f00c31e35be5") },
                    { "FIRSTMODELNAME ver1 DOc B", "Chroming", "FIRSTMODELNAME", 1, null, new Guid("7808711f-544a-423d-8d99-f00c31e35be5") },
                    { "FIRSTMODELNAME ver1 DOc B", "Sealing", "FIRSTMODELNAME", 1, null, new Guid("7808711f-544a-423d-8d99-f00c31e35be5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacitySpecification_ModelName_ModelVersionId",
                table: "CapacitySpecification",
                columns: new[] { "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_CapacitySpecification_ShellMaterialName",
                table: "CapacitySpecification",
                column: "ShellMaterialName");

            migrationBuilder.CreateIndex(
                name: "IX_CapacityTestPoint_Capacity_ModelName_ModelVersionId",
                table: "CapacityTestPoint",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Document_ModelName_ModelVersionId",
                table: "Document",
                columns: new[] { "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDocumentType_DocumentTypeTypeName",
                table: "DocumentDocumentType",
                column: "DocumentTypeTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelTypesName",
                table: "Models",
                column: "ModelTypesName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacityTestPoint");

            migrationBuilder.DropTable(
                name: "DocumentDocumentType");

            migrationBuilder.DropTable(
                name: "HigherModel");

            migrationBuilder.DropTable(
                name: "CapacitySpecification");

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
