using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modeldbtype4 : Migration
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
                    ModelTypeId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
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
                    ModelTypesId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    { "HigherModel1", 1, "HigherModel1", "661e263b-f5b5-4458-86ec-4468b9e24d98", "HigherModel1" },
                    { "HigherModel2", 12, "HigherModel12", "12532b43-bd99-42d8-aca0-153f27b68807", "HigherModel12" },
                    { "HigherModel3", 13, "HigherModel1", "c85835c5-d4eb-48dd-8f09-a0aeb7c50407", "HigherModel13" },
                    { "HigherModel4", 14, "HigherModel14", "23d0efc7-cc86-4a1e-ad60-759bca831151", "HigherModel14" },
                    { "HigherModel5", 5, "HigherModel5", "b1a1f3ba-f977-401c-b2d1-5ab350f40fe1", "HigherModel5" }
                });

            migrationBuilder.InsertData(
                table: "ModelType",
                columns: new[] { "ModelTypeId", "ModelTypeName" },
                values: new object[,]
                {
                    { "FIRSTMODELTYPEID", "FIRSTMODELTYPE" },
                    { "SECONDMODELTYPEID", "SECONDMODELTYPE" },
                    { "THIRDMODELTYPEID", "THIRDMODELTYPE" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelId", "ModelName", "ModelTypesId" },
                values: new object[,]
                {
                    { "FIRSTMODELID1", "FIRSTMODELNAME1", "FIRSTMODELTYPEID" },
                    { "FIRSTMODELID2", "FIRSTMODELNAME2", "FIRSTMODELTYPEID" },
                    { "FIRSTMODELID3", "FIRSTMODELNAME2", "FIRSTMODELTYPEID" },
                    { "SECONDMODELID1", "SECONDMODELNAME1", "SECONDMODELTYPEID" },
                    { "THIRDMODELD1", "THIRDMODELNAME1", "THIRDMODELTYPEID" }
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
