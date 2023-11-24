using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secfgsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(128)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Stage = table.Column<string>(type: "longtext", nullable: false),
                    SubStage = table.Column<string>(type: "longtext", nullable: false),
                    InvoiceId = table.Column<string>(type: "longtext", nullable: false),
                    SalesOrderId = table.Column<string>(type: "longtext", nullable: false),
                    CableLength = table.Column<int>(type: "int", nullable: false),
                    Troubled = table.Column<int>(type: "int", nullable: false),
                    TestingModeName = table.Column<string>(type: "longtext", nullable: false),
                    ThermexPurcharseOrderNo = table.Column<string>(type: "longtext", nullable: false),
                    MachiningPurcharseOrderNo = table.Column<string>(type: "longtext", nullable: false),
                    SteelPurcharseOrderNo = table.Column<string>(type: "longtext", nullable: false),
                    MetalCertificateNo = table.Column<string>(type: "longtext", nullable: false),
                    BatcNo = table.Column<string>(type: "longtext", nullable: false),
                    GuidId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ModelVersion_ModelName_ModelVersionId",
                        columns: x => new { x.ModelName, x.ModelVersionId },
                        principalTable: "ModelVersion",
                        principalColumns: new[] { "ModelName", "ModelVersionId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7255), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7255), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7280), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7280), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7282), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7283), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 101, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7273), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7273), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 102, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7277), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7277), new DateTime(2023, 11, 22, 17, 33, 36, 686, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 688, DateTimeKind.Utc).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 688, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 688, DateTimeKind.Utc).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 688, DateTimeKind.Utc).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 692, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 692, DateTimeKind.Utc).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 33, 36, 692, DateTimeKind.Utc).AddTicks(4399));

            migrationBuilder.CreateIndex(
                name: "IX_Product_ModelName_ModelVersionId",
                table: "Product",
                columns: new[] { "ModelName", "ModelVersionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9865), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9866), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9864) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "FIRSTMODELNAME", 2 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9889), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9890), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9889) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 100, "SECONDMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9892), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9892), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9892) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 101, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9883), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9883), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9883) });

            migrationBuilder.UpdateData(
                table: "CapacitySpecification",
                keyColumns: new[] { "Capacity", "ModelName", "ModelVersionId" },
                keyValues: new object[] { 102, "FIRSTMODELNAME", 1 },
                columns: new[] { "NTEPCertificationTimestamp", "OIMLCertificationTimestamp", "Timestamp" },
                values: new object[] { new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9886), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9887), new DateTime(2023, 11, 22, 17, 17, 33, 595, DateTimeKind.Utc).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 598, DateTimeKind.Utc).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc A", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 598, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver1 DOc B", "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 598, DateTimeKind.Utc).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Document",
                keyColumns: new[] { "DocumentName", "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME ver2 DOc A", "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 598, DateTimeKind.Utc).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 600, DateTimeKind.Utc).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "FIRSTMODELNAME", 2 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 600, DateTimeKind.Utc).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "ModelVersion",
                keyColumns: new[] { "ModelName", "ModelVersionId" },
                keyValues: new object[] { "SECONDMODELNAME", 1 },
                column: "Timestamp",
                value: new DateTime(2023, 11, 22, 17, 17, 33, 600, DateTimeKind.Utc).AddTicks(9876));
        }
    }
}
