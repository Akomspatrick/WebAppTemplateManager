using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
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
                    ModelTypeId = table.Column<string>(type: "varchar(68)", maxLength: 68, nullable: false),
                    ModelTypeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelType", x => x.ModelTypeId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ModelName = table.Column<string>(type: "longtext", nullable: false),
                    ModelTypesId = table.Column<string>(type: "varchar(68)", maxLength: 68, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_ModelType_ModelTypesId",
                        column: x => x.ModelTypesId,
                        principalTable: "ModelType",
                        principalColumn: "ModelTypeId",
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
                    { "HigherModel1", 1, "HigherModel1", "ab82ec7a-521b-413e-8963-b8ede089be0c", "HigherModel1" },
                    { "HigherModel2", 12, "HigherModel12", "7eb659b1-c967-4f20-bf86-e035f80b342f", "HigherModel12" },
                    { "HigherModel3", 13, "HigherModel1", "dae2a838-7ea4-4ba1-893b-ac365863a066", "HigherModel13" },
                    { "HigherModel4", 14, "HigherModel14", "13c57cb9-26a7-457f-a454-9a5d49c357e3", "HigherModel14" },
                    { "HigherModel5", 5, "HigherModel5", "661216e5-a65f-4ef4-998e-f1f9f2a3ed86", "HigherModel5" }
                });

            migrationBuilder.InsertData(
                table: "ModelType",
                columns: new[] { "ModelTypeId", "ModelTypeName" },
                values: new object[,]
                {
                    { "123456789012345678901234567890123413", "THIRDMODELTYPE" },
                    { "123456789012345678901234567890123451", "FIRSTMODELTYPE" },
                    { "123456789012345678901234567890123462", "SECONDMODELTYPE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelTypesId",
                table: "Models",
                column: "ModelTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "HigherModel");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ModelType");
        }
    }
}
