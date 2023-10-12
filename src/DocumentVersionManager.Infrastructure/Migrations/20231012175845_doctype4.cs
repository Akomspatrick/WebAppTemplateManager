using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class doctype4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelTypeId",
                table: "ModelType",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "HigherModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HigherModelDescription",
                table: "HigherModel",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "HigherModel",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel1",
                columns: new[] { "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[] { 1, "HigherModel1", "27822737-8b18-4c5b-be06-4bfbfe72d25f", "HigherModel1" });

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel2",
                columns: new[] { "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[] { 12, "HigherModel12", "139833d1-f304-4840-9f7d-d5023cc3fe8c", "HigherModel12" });

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel3",
                columns: new[] { "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[] { 13, "HigherModel1", "06e2729e-7ec0-46e7-a8b8-75477dad0575", "HigherModel13" });

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel4",
                columns: new[] { "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[] { 14, "HigherModel14", "67054838-96a6-4730-9fac-829f0709408e", "HigherModel14" });

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel5",
                columns: new[] { "Capacity", "HigherModelDescription", "Id", "ProductId" },
                values: new object[] { 5, "HigherModel5", "47d4c3d0-caf9-40a6-a978-aa52684b72f6", "HigherModel5" });

            migrationBuilder.UpdateData(
                table: "ModelType",
                keyColumn: "ModelTypeName",
                keyValue: "FIRSTMODELTYPE",
                column: "ModelTypeId",
                value: "FIRSTMODELTYPE");

            migrationBuilder.UpdateData(
                table: "ModelType",
                keyColumn: "ModelTypeName",
                keyValue: "SECONDMODELTYPE",
                column: "ModelTypeId",
                value: "SECONDMODELTYPE");

            migrationBuilder.UpdateData(
                table: "ModelType",
                keyColumn: "ModelTypeName",
                keyValue: "THIRDMODELTYPE",
                column: "ModelTypeId",
                value: "THIRDMODELTYPE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelTypeId",
                table: "ModelType");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "HigherModel");

            migrationBuilder.DropColumn(
                name: "HigherModelDescription",
                table: "HigherModel");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "HigherModel");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel1",
                column: "Id",
                value: "a3344eec-2da3-49b4-aeb3-ac70f4973bf5");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel2",
                column: "Id",
                value: "d97a7d19-9748-4346-999a-cfb0c5d6ef7d");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel3",
                column: "Id",
                value: "e7194d47-5078-4aed-b2bd-88e338d9d665");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel4",
                column: "Id",
                value: "da7452a5-4b37-4443-9ed6-d76f1680f176");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel5",
                column: "Id",
                value: "a84c2888-2f82-4f56-b1c4-f26b82be5e51");
        }
    }
}
