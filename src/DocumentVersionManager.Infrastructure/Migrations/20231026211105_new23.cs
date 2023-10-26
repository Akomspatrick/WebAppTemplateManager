using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel1",
                column: "Id",
                value: "20bef0a3-834d-4d70-acd6-d4d0253cc0c5");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel2",
                column: "Id",
                value: "2605f765-870f-4178-9a15-994021aaa313");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel3",
                column: "Id",
                value: "a07f25b9-bf40-42db-a7c0-a508a73c464e");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel4",
                column: "Id",
                value: "c29e8f51-b42b-4082-a0bd-f2a2824e7738");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel5",
                column: "Id",
                value: "9b9419a2-e11e-45a6-9601-392aff3c267c");

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelId", "ModelName", "ModelTypesId" },
                values: new object[,]
                {
                    { "FIRSTMODELID1", "FIRSTMODELNAME1", "123456789012345678901234567890123451" },
                    { "FIRSTMODELID2", "FIRSTMODELNAME2", "123456789012345678901234567890123451" },
                    { "FIRSTMODELID3", "FIRSTMODELNAME2", "123456789012345678901234567890123451" },
                    { "SECONDMODELID1", "SECONDMODELNAME1", "123456789012345678901234567890123462" },
                    { "THIRDMODELD1", "THIRDMODELNAME1", "123456789012345678901234567890123473" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ModelId",
                keyValue: "FIRSTMODELID1");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ModelId",
                keyValue: "FIRSTMODELID2");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ModelId",
                keyValue: "FIRSTMODELID3");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ModelId",
                keyValue: "SECONDMODELID1");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ModelId",
                keyValue: "THIRDMODELD1");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel1",
                column: "Id",
                value: "ab82ec7a-521b-413e-8963-b8ede089be0c");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel2",
                column: "Id",
                value: "7eb659b1-c967-4f20-bf86-e035f80b342f");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel3",
                column: "Id",
                value: "dae2a838-7ea4-4ba1-893b-ac365863a066");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel4",
                column: "Id",
                value: "13c57cb9-26a7-457f-a454-9a5d49c357e3");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel5",
                column: "Id",
                value: "661216e5-a65f-4ef4-998e-f1f9f2a3ed86");
        }
    }
}
