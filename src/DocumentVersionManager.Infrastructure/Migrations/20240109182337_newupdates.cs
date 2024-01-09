using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4706), new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4707), new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4735), new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4735), new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4740), new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4741), new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4740) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 4, 0, 4, 4, 991, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 4, 0, 4, 4, 991, DateTimeKind.Utc).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 4, 0, 4, 4, 991, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2024, 1, 4, 0, 4, 4, 991, DateTimeKind.Utc).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3306), new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3306), new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3329), new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3330), new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3333), new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3333), new DateTime(2024, 1, 4, 0, 4, 4, 996, DateTimeKind.Utc).AddTicks(3332) });
        }
    }
}
