﻿// <auto-generated />
using DocumentVersionManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    [DbContext(typeof(DocumentVersionManagerContext))]
    [Migration("20231026210948_new2")]
    partial class new2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.DocumentType", b =>
                {
                    b.Property<string>("TypeName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("TypeName");

                    b.ToTable("DocumentType");

                    b.HasData(
                        new
                        {
                            TypeName = "Cabling"
                        },
                        new
                        {
                            TypeName = "Chroming"
                        },
                        new
                        {
                            TypeName = "Sealing"
                        },
                        new
                        {
                            TypeName = "Gauging"
                        },
                        new
                        {
                            TypeName = "Wiring"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.HigherModel", b =>
                {
                    b.Property<string>("HigherModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("HigherModelDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("HigherModelName");

                    b.ToTable("HigherModel");

                    b.HasData(
                        new
                        {
                            HigherModelName = "HigherModel1",
                            Capacity = 1,
                            HigherModelDescription = "HigherModel1",
                            Id = "ab82ec7a-521b-413e-8963-b8ede089be0c",
                            ProductId = "HigherModel1"
                        },
                        new
                        {
                            HigherModelName = "HigherModel2",
                            Capacity = 12,
                            HigherModelDescription = "HigherModel12",
                            Id = "7eb659b1-c967-4f20-bf86-e035f80b342f",
                            ProductId = "HigherModel12"
                        },
                        new
                        {
                            HigherModelName = "HigherModel3",
                            Capacity = 13,
                            HigherModelDescription = "HigherModel1",
                            Id = "dae2a838-7ea4-4ba1-893b-ac365863a066",
                            ProductId = "HigherModel13"
                        },
                        new
                        {
                            HigherModelName = "HigherModel4",
                            Capacity = 14,
                            HigherModelDescription = "HigherModel14",
                            Id = "13c57cb9-26a7-457f-a454-9a5d49c357e3",
                            ProductId = "HigherModel14"
                        },
                        new
                        {
                            HigherModelName = "HigherModel5",
                            Capacity = 5,
                            HigherModelDescription = "HigherModel5",
                            Id = "661216e5-a65f-4ef4-998e-f1f9f2a3ed86",
                            ProductId = "HigherModel5"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model", b =>
                {
                    b.Property<string>("ModelId")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModelTypesId")
                        .IsRequired()
                        .HasMaxLength(68)
                        .HasColumnType("varchar(68)");

                    b.HasKey("ModelId");

                    b.HasIndex("ModelTypesId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", b =>
                {
                    b.Property<string>("ModelTypeId")
                        .HasMaxLength(68)
                        .HasColumnType("varchar(68)");

                    b.Property<string>("ModelTypeName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("ModelTypeId");

                    b.ToTable("ModelType");

                    b.HasData(
                        new
                        {
                            ModelTypeId = "123456789012345678901234567890123451",
                            ModelTypeName = "FIRSTMODELTYPE"
                        },
                        new
                        {
                            ModelTypeId = "123456789012345678901234567890123462",
                            ModelTypeName = "SECONDMODELTYPE"
                        },
                        new
                        {
                            ModelTypeId = "123456789012345678901234567890123413",
                            ModelTypeName = "THIRDMODELTYPE"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", "ModelTypes")
                        .WithMany("Models")
                        .HasForeignKey("ModelTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTypes");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}