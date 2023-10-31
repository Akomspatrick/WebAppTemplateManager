using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SEC : Migration
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
                    DocumentTypeGuid = table.Column<Guid>(type: "char(36)", nullable: false)
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
                    ModelTypesId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Alloy = table.Column<int>(type: "int", nullable: false),
                    ShellMaterialGuid = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShellMaterial", x => new { x.Name, x.Alloy });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ModelId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ModelTypesName = table.Column<string>(type: "varchar(128)", nullable: false)
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
                    ModelVersionGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
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
                    ShellMaterialName = table.Column<string>(type: "longtext", nullable: false),
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
                    CapacitySpecificationGuid = table.Column<Guid>(type: "char(36)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    DocumentGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContentPDFPath = table.Column<string>(type: "longtext", nullable: false),
                    ChangeOrderPDFPath = table.Column<string>(type: "longtext", nullable: false),
                    DocumentDescription = table.Column<string>(type: "longtext", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CapacityTestPointGuid = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityTestPoint", x => new { x.ModelVersionId, x.ModelName, x.TestId });
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
                    DocumentDocumentTypeGuid = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDocumentType", x => new { x.DocumentName, x.ModelName, x.ModelVersionId, x.DocumentTypeName });
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
                columns: new[] { "TypeName", "DocumentTypeGuid" },
                values: new object[,]
                {
                    { "Cabling", new Guid("00000000-0000-0000-0000-000000000000") },
                    { "Chroming", new Guid("00000000-0000-0000-0000-000000000000") },
                    { "Gauging", new Guid("00000000-0000-0000-0000-000000000000") },
                    { "Sealing", new Guid("00000000-0000-0000-0000-000000000000") },
                    { "Wiring", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "HigherModel",
                columns: new[] { "HigherModelName", "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[,]
                {
                    { "HigherModel1", 1, "HigherModel1", "a54b3659-697e-4732-9ab5-ec43c2c103bd", "HigherModel1" },
                    { "HigherModel2", 12, "HigherModel12", "773d2b35-8572-4cae-a694-d216435fdd2b", "HigherModel12" },
                    { "HigherModel3", 13, "HigherModel1", "7b4b5b41-2c52-4cf9-a39a-ed059b8d80b6", "HigherModel13" },
                    { "HigherModel4", 14, "HigherModel14", "842a9f3f-2b1a-4a24-a9b8-b3e5a20c4660", "HigherModel14" },
                    { "HigherModel5", 5, "HigherModel5", "cdbdc281-74ec-4428-b7b7-466a4ee985ea", "HigherModel5" }
                });

            migrationBuilder.InsertData(
                table: "ModelType",
                columns: new[] { "ModelTypesName", "ModelTypesId" },
                values: new object[,]
                {
                    { "FIRSTMODELTYPE", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { "SECONDMODELTYPE", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b") },
                    { "THIRDMODELTYPE", new Guid("3c69923e-a68e-4348-b06c-7007f527355d") }
                });

            migrationBuilder.InsertData(
                table: "ShellMaterial",
                columns: new[] { "Alloy", "Name", "ShellMaterialGuid" },
                values: new object[,]
                {
                    { 1, "ShellMAterial1", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 2, "ShellMAterial1", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 1, "ShellMAterial2", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") },
                    { 2, "ShellMAterial2", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63") }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelName", "ModelId", "ModelTypesName" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELTYPE" },
                    { "SECONDMODELNAME", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELTYPE" },
                    { "THIRDMODELNAME", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "SECONDMODELTYPE" }
                });

            migrationBuilder.InsertData(
                table: "ModelVersion",
                columns: new[] { "ModelName", "ModelVersionId", "ModelVersionGuid", "ModelVersionName", "Timestamp", "Username", "VersionDescription" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRST_VERSION_FIRSTMODEL_NAME", new DateTime(2023, 10, 31, 22, 30, 6, 777, DateTimeKind.Utc).AddTicks(870), "OLADEJI", "SPECIAL DESIGN" },
                    { "FIRSTMODELNAME", 2, new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "SECOND_VERSION_FIRSTMODELNAME", new DateTime(2023, 10, 31, 22, 30, 6, 777, DateTimeKind.Utc).AddTicks(880), "OLADEJI", "AUTO DESIGN TO COMBAT SPLIILING" },
                    { "SECONDMODELNAME", 1, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRST_VERSION_SECONDMODELNAME", new DateTime(2023, 10, 31, 22, 30, 6, 777, DateTimeKind.Utc).AddTicks(882), "OLADEJI", "INITIAL DESIGN" }
                });

            migrationBuilder.InsertData(
                table: "CapacitySpecification",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId", "Alloy", "Application", "AustenitizationHardnessHigh", "AustenitizationHardnessLow", "AustenitizationTemperatureInF", "AustenitizationTimeInSeconds", "CCNumber", "CapacitySpecificationGuid", "Class", "DefaultCableLength", "HasScrews", "MinimumDeadLoad", "NTEPCertificationId", "NTEPCertificationTimestamp", "NominalOutput", "NominalOutputPercentage", "NonlinearityPercentage", "NumberInBasket", "NumberOfGauges", "OIMLCertificationId", "OIMLCertificationTimestamp", "Resistance", "SafeLoad", "ShellMaterialName", "TempRangeHigh", "TempRangeLow", "TemperingHardnessHigh", "TemperingHardnessLow", "TemperingTemperatureInF", "TemperingTimeInSeconds", "Timestamp", "UltimateLoad", "Username", "nMax", "vMin" },
                values: new object[,]
                {
                    { 100, "FIRSTMODELNAME", 1, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "CLASS", 20, true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9295), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID1", new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9303), 1, 1, "SHELLMATERIAL1", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9286), 1, "OLADEJI", 1, 1.0 },
                    { 100, "FIRSTMODELNAME", 2, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "CLASS", 20, true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9328), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID2", new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9328), 1, 1, "SHELLMATERIAL2", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9324), 1, "OLADEJI", 1, 1.0 },
                    { 100, "SECONDMODELNAME", 1, true, "APPLICATION", 1, 1, 1.0, 1, "CCNUMBER", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "CLASS", 20, true, 1, "NTEPCERTIFICATIONID", new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9335), 1.0, 1m, 1m, 1, 1, "OIMLCERTIFICATIONID3", new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9335), 1, 1, "SHELLMATERIAL3", 1, 1, 1, 1, 1.0, 1, new DateTime(2023, 10, 31, 22, 30, 6, 770, DateTimeKind.Utc).AddTicks(9332), 1, "OLADEJI", 1, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "DocumentName", "ModelName", "ModelVersionId", "ChangeOrderPDFPath", "ContentPDFPath", "DocumentDescription", "DocumentGuid", "Timestamp" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 10, 31, 22, 30, 6, 773, DateTimeKind.Utc).AddTicks(1503) },
                    { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 10, 31, 22, 30, 6, 773, DateTimeKind.Utc).AddTicks(1526) },
                    { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), new DateTime(2023, 10, 31, 22, 30, 6, 773, DateTimeKind.Utc).AddTicks(1531) },
                    { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), new DateTime(2023, 10, 31, 22, 30, 6, 773, DateTimeKind.Utc).AddTicks(1534) }
                });

            migrationBuilder.InsertData(
                table: "CapacityTestPoint",
                columns: new[] { "ModelName", "ModelVersionId", "TestId", "Capacity", "CapacityTestPointGuid", "Weight" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME", 1, 0, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), 1 },
                    { "SECONDMODELNAME", 1, 0, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), 1 },
                    { "FIRSTMODELNAME", 2, 0, 100, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), 1 }
                });

            migrationBuilder.InsertData(
                table: "DocumentDocumentType",
                columns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId", "DocumentDocumentTypeGuid" },
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
                name: "IX_CapacitySpecification_ModelName_ModelVersionId",
                table: "CapacitySpecification",
                columns: new[] { "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_CapacityTestPoint_Capacity_ModelName_ModelVersionId",
                table: "CapacityTestPoint",
                columns: new[] { "Capacity", "ModelName", "ModelVersionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Document_ModelName_ModelVersionId",
                table: "Document",
                columns: new[] { "ModelName", "ModelVersionId" });

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
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "HigherModel");

            migrationBuilder.DropTable(
                name: "ShellMaterial");

            migrationBuilder.DropTable(
                name: "CapacitySpecification");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ModelVersion");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ModelType");
        }
    }
}
