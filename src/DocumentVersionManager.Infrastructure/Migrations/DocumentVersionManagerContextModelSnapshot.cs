﻿// <auto-generated />
using DocumentVersionManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    [DbContext(typeof(DocumentVersionManagerContext))]
    partial class DocumentVersionManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = "e91ad76a-eb23-43be-ad34-4ff48671a29f",
                            ProductId = "HigherModel1"
                        },
                        new
                        {
                            HigherModelName = "HigherModel2",
                            Capacity = 12,
                            HigherModelDescription = "HigherModel12",
                            Id = "55b0cc5e-371b-4ccf-b8c9-24d921d50594",
                            ProductId = "HigherModel12"
                        },
                        new
                        {
                            HigherModelName = "HigherModel3",
                            Capacity = 13,
                            HigherModelDescription = "HigherModel1",
                            Id = "da4a7dc7-3563-4cff-a8b9-c60779881292",
                            ProductId = "HigherModel13"
                        },
                        new
                        {
                            HigherModelName = "HigherModel4",
                            Capacity = 14,
                            HigherModelDescription = "HigherModel14",
                            Id = "99d6b153-3712-4325-962a-25e49e68ca39",
                            ProductId = "HigherModel14"
                        },
                        new
                        {
                            HigherModelName = "HigherModel5",
                            Capacity = 5,
                            HigherModelDescription = "HigherModel5",
                            Id = "18c58b0e-be3d-4a95-9bd1-c946574edf09",
                            ProductId = "HigherModel5"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", b =>
                {
                    b.Property<string>("ModelTypeId")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ModelTypeName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("ModelTypeId");

                    b.ToTable("ModelType");

                    b.HasData(
                        new
                        {
                            ModelTypeId = "FIRSTMODELTYPEID",
                            ModelTypeName = "FIRSTMODELTYPE"
                        },
                        new
                        {
                            ModelTypeId = "SECONDMODELTYPEID",
                            ModelTypeName = "SECONDMODELTYPE"
                        },
                        new
                        {
                            ModelTypeId = "THIRDMODELTYPEID",
                            ModelTypeName = "THIRDMODELTYPE"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
