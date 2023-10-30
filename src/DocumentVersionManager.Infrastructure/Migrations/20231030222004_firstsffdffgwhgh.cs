using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstsffdffgwhgh : Migration
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
                    { "HigherModel1", 1, "HigherModel1", "1852aac1-dec0-4047-bdc8-5036693ecb5c", "HigherModel1" },
                    { "HigherModel2", 12, "HigherModel12", "4e22b341-b053-4c17-baae-a1334d58a6a7", "HigherModel12" },
                    { "HigherModel3", 13, "HigherModel1", "5892b5c7-d879-4b23-9ddf-af509a293786", "HigherModel13" },
                    { "HigherModel4", 14, "HigherModel14", "2eb429a6-ce6b-47fd-ade6-556f1e6aa6ff", "HigherModel14" },
                    { "HigherModel5", 5, "HigherModel5", "a517b7c2-1695-4fec-8595-dcc5605dd0ac", "HigherModel5" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelTypesName",
                table: "Models",
                column: "ModelTypesName");
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
