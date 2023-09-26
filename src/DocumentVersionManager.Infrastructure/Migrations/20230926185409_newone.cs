using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "ProductModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "ModelName");

            migrationBuilder.CreateTable(
                name: "ModelType",
                columns: table => new
                {
                    ModelName = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelType", x => x.ModelName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Model");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "ModelName");
        }
    }
}
