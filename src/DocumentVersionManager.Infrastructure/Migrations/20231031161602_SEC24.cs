using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SEC24 : Migration
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
                    TypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
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
                name: "Document",
                columns: table => new
                {
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    DocumentNameGuid = table.Column<Guid>(type: "char(36)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "DocumentType",
                column: "TypeName",
                values: new object[]
                {
                    "Cabling",
                    "Chroming",
                    "Gauging",
                    "Sealing",
                    "Wiring"
                });

            migrationBuilder.InsertData(
                table: "HigherModel",
                columns: new[] { "HigherModelName", "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[,]
                {
                    { "HigherModel1", 1, "HigherModel1", "567ae306-4c5c-437c-871e-012c7816f60b", "HigherModel1" },
                    { "HigherModel2", 12, "HigherModel12", "0365eb1f-a181-4dd0-b95f-5313ec51a885", "HigherModel12" },
                    { "HigherModel3", 13, "HigherModel1", "d83447c4-f6f5-4e95-bae0-d73b5221cdec", "HigherModel13" },
                    { "HigherModel4", 14, "HigherModel14", "bc46a5b8-c975-490d-b769-eac3ba435869", "HigherModel14" },
                    { "HigherModel5", 5, "HigherModel5", "ad8c9743-168d-412e-965e-0a514937c539", "HigherModel5" }
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
                    { "FIRSTMODELNAME", 1, new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRST_VERSION_FIRSTMODEL_NAME", new DateTime(2023, 10, 31, 16, 16, 2, 653, DateTimeKind.Utc).AddTicks(6268), "OLADEJI", "SPECIAL DESIGN" },
                    { "FIRSTMODELNAME", 2, new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), "SECOND_VERSION_FIRSTMODELNAME", new DateTime(2023, 10, 31, 16, 16, 2, 653, DateTimeKind.Utc).AddTicks(6285), "OLADEJI", "AUTO DESIGN TO COMBAT SPLIILING" },
                    { "SECONDMODELNAME", 1, new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRST_VERSION_SECONDMODELNAME", new DateTime(2023, 10, 31, 16, 16, 2, 653, DateTimeKind.Utc).AddTicks(6287), "OLADEJI", "INITIAL DESIGN" }
                });

            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "DocumentName", "ModelName", "ModelVersionId", "ChangeOrderPDFPath", "ContentPDFPath", "DocumentDescription", "DocumentNameGuid", "Timestamp" },
                values: new object[,]
                {
                    { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5455) },
                    { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5464) },
                    { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("7808711f-544a-423d-8d99-f00c31e35be5"), new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5467) },
                    { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2, "CHANGE ORDER PATH", "CONTENT PDF PATH", "SIMPLE DESCRITION OF DOCUMENT", new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5469) }
                });

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
                name: "Document");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "HigherModel");

            migrationBuilder.DropTable(
                name: "ModelVersion");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ModelType");
        }
    }
}
