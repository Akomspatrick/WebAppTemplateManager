using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class doctype3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HigherModel",
                columns: table => new
                {
                    HigherModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherModel", x => x.HigherModelName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "HigherModel",
                columns: new[] { "HigherModelName", "Id" },
                values: new object[,]
                {
                    { "HigherModel1", "a3344eec-2da3-49b4-aeb3-ac70f4973bf5" },
                    { "HigherModel2", "d97a7d19-9748-4346-999a-cfb0c5d6ef7d" },
                    { "HigherModel3", "e7194d47-5078-4aed-b2bd-88e338d9d665" },
                    { "HigherModel4", "da7452a5-4b37-4443-9ed6-d76f1680f176" },
                    { "HigherModel5", "a84c2888-2f82-4f56-b1c4-f26b82be5e51" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HigherModel");
        }
    }
}
