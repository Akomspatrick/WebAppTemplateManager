using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "ModelVersions",
                newName: "AccuracyClass");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "DOCPATHID", new DateTime(2023, 12, 20, 21, 28, 36, 544, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "DOCPATHID", new DateTime(2023, 12, 20, 21, 28, 36, 544, DateTimeKind.Utc).AddTicks(5391) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "DOCPATHID", new DateTime(2023, 12, 20, 21, 28, 36, 544, DateTimeKind.Utc).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "DOCPATHID", new DateTime(2023, 12, 20, 21, 28, 36, 544, DateTimeKind.Utc).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(377), new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(377), new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(375) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(397), new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(398), new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(402), new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(402), new DateTime(2023, 12, 20, 21, 28, 36, 549, DateTimeKind.Utc).AddTicks(401) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccuracyClass",
                table: "ModelVersions",
                newName: "Class");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceId",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "001", new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5385) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "001", new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5397) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "001", new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                columns: new[] { "DocumentBasePathId", "Timestamp" },
                values: new object[] { "001", new DateTime(2023, 12, 13, 19, 26, 38, 551, DateTimeKind.Utc).AddTicks(5402) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5061), new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5062), new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5082), new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5082), new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "ModelVersions",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5086), new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5086), new DateTime(2023, 12, 13, 19, 26, 38, 556, DateTimeKind.Utc).AddTicks(5086) });
        }
    }
}
