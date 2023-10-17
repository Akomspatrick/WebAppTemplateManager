using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modeldbtype : Migration
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
                    { "HigherModel1", 1, "HigherModel1", "e91ad76a-eb23-43be-ad34-4ff48671a29f", "HigherModel1" },
                    { "HigherModel2", 12, "HigherModel12", "55b0cc5e-371b-4ccf-b8c9-24d921d50594", "HigherModel12" },
                    { "HigherModel3", 13, "HigherModel1", "da4a7dc7-3563-4cff-a8b9-c60779881292", "HigherModel13" },
                    { "HigherModel4", 14, "HigherModel14", "99d6b153-3712-4325-962a-25e49e68ca39", "HigherModel14" },
                    { "HigherModel5", 5, "HigherModel5", "18c58b0e-be3d-4a95-9bd1-c946574edf09", "HigherModel5" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "HigherModel");

            migrationBuilder.DropTable(
                name: "ModelType");
        }
    }
}
