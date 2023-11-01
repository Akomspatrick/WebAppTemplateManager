using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TES4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentTypeTypeName",
                table: "DocumentDocumentType",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1848), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1850), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1941), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1945), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1937) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1954), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1954), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1951) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 101, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1920), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1921), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1917) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 102, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1932), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1932), new DateTime(2023, 11, 1, 18, 3, 3, 857, DateTimeKind.Utc).AddTicks(1928) });

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 858, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 858, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 858, DateTimeKind.Utc).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 858, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "DocumentDocumentType",
                keyColumns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "Cabling", "FIRSTMODELNAME", 1 },
                column: "DocumentTypeTypeName",
                value: null);

            migrationBuilder.UpdateData(
                table: "DocumentDocumentType",
                keyColumns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "Chroming", "FIRSTMODELNAME", 1 },
                column: "DocumentTypeTypeName",
                value: null);

            migrationBuilder.UpdateData(
                table: "DocumentDocumentType",
                keyColumns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "Sealing", "FIRSTMODELNAME", 1 },
                column: "DocumentTypeTypeName",
                value: null);

            migrationBuilder.UpdateData(
                table: "DocumentDocumentType",
                keyColumns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "Cabling", "FIRSTMODELNAME", 1 },
                column: "DocumentTypeTypeName",
                value: null);

            migrationBuilder.UpdateData(
                table: "DocumentDocumentType",
                keyColumns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "Chroming", "FIRSTMODELNAME", 1 },
                column: "DocumentTypeTypeName",
                value: null);

            migrationBuilder.UpdateData(
                table: "DocumentDocumentType",
                keyColumns: new[] { "DocumentName", "DocumentTypeName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "Sealing", "FIRSTMODELNAME", 1 },
                column: "DocumentTypeTypeName",
                value: null);

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel1",
                column: "Id",
                value: "b6b502de-cdd9-412d-98d0-f5deb82de738");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel2",
                column: "Id",
                value: "115070fb-9bda-4366-84f6-47a43684db58");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel3",
                column: "Id",
                value: "89c90b92-222b-4ffb-ab03-167286788ef0");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel4",
                column: "Id",
                value: "64d1b73c-5e14-4a4b-b980-456d1bbab189");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel5",
                column: "Id",
                value: "79ca4abb-01d1-4c27-aa27-e8a3800dec5d");

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 862, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 862, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 18, 3, 3, 862, DateTimeKind.Utc).AddTicks(2580));

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDocumentType_DocumentTypeTypeName",
                table: "DocumentDocumentType",
                column: "DocumentTypeTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDocumentType_DocumentType_DocumentTypeTypeName",
                table: "DocumentDocumentType",
                column: "DocumentTypeTypeName",
                principalTable: "DocumentType",
                principalColumn: "TypeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDocumentType_DocumentType_DocumentTypeTypeName",
                table: "DocumentDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_DocumentDocumentType_DocumentTypeTypeName",
                table: "DocumentDocumentType");

            migrationBuilder.DropColumn(
                name: "DocumentTypeTypeName",
                table: "DocumentDocumentType");

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3417), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3420), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3503), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3503), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3509), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3509), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 101, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3443), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3444), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 102, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3450), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3451), new DateTime(2023, 11, 1, 17, 35, 39, 462, DateTimeKind.Utc).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 463, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 463, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 463, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 463, DateTimeKind.Utc).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel1",
                column: "Id",
                value: "d805ad4c-c665-4f62-84fd-ca99cf5c69d8");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel2",
                column: "Id",
                value: "4a0b2ce7-b736-4257-b09f-88155f762b13");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel3",
                column: "Id",
                value: "65dd78e8-ae9d-47a2-8e1d-05eaea796a31");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel4",
                column: "Id",
                value: "d11f7fbc-dd0b-4d35-b83b-7a44215771b5");

            migrationBuilder.UpdateData(
                table: "HigherModel",
                keyColumn: "HigherModelName",
                keyValue: "HigherModel5",
                column: "Id",
                value: "e23d1499-3c57-41f6-b5d3-0976a7237238");

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 467, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 467, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 1, 17, 35, 39, 467, DateTimeKind.Utc).AddTicks(916));
        }
    }
}
