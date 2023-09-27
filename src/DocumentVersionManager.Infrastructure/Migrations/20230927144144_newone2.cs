using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newone2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModelTypeName",
                table: "ModelType",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.InsertData(
                table: "ModelType",
                column: "ModelTypeName",
                values: new object[]
                {
                    "FIRSTMODELTYPE",
                    "SECONDMODELTYPE",
                    "THIRDMODELTYPE"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelType",
                keyColumn: "ModelTypeName",
                keyValue: "FIRSTMODELTYPE");

            migrationBuilder.DeleteData(
                table: "ModelType",
                keyColumn: "ModelTypeName",
                keyValue: "SECONDMODELTYPE");

            migrationBuilder.DeleteData(
                table: "ModelType",
                keyColumn: "ModelTypeName",
                keyValue: "THIRDMODELTYPE");

            migrationBuilder.AlterColumn<string>(
                name: "ModelTypeName",
                table: "ModelType",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128);
        }
    }
}
