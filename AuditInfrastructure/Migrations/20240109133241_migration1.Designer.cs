﻿// <auto-generated />
using System;
using AuditInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuditInfrastructure.Migrations
{
    [DbContext(typeof(AuditDbContext))]
    [Migration("20240109133241_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuditDomain.Entity.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("GoalOfAudit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeOfCreating")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeOfAudit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("AuditDomain.Entity.AuditUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuditId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("UserId");

                    b.ToTable("AuditUsers");
                });

            modelBuilder.Entity("AuditDomain.Entity.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubUnitBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitBranch")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("AuditDomain.Entity.Discrepancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnotherDiscrepancyRequirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AuditId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfContorolNoticed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfDetection")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionOfDiscrepancy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscrepancyType")
                        .HasColumnType("int");

                    b.Property<string>("ReasonOfDiscrepancy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.HasIndex("StatusId");

                    b.ToTable("Discrepancys");
                });

            modelBuilder.Entity("AuditDomain.Entity.IsoDirectory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ISOName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfISOStandart")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IsoDirectories");
                });

            modelBuilder.Entity("AuditDomain.Entity.IsoDiscrepancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiscrepancyId")
                        .HasColumnType("int");

                    b.Property<int>("IsoDirectoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscrepancyId");

                    b.HasIndex("IsoDirectoryId");

                    b.ToTable("IsoDiscrepancy");
                });

            modelBuilder.Entity("AuditDomain.Entity.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameOfPosition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("AuditDomain.Entity.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Finished")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionOfPrescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("ViolationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("When_Created")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("ViolationId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("AuditDomain.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AuditDomain.Entity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AuditDomain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuditDomain.Entity.UserViolation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ViolationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ViolationId");

                    b.ToTable("UserViolations");
                });

            modelBuilder.Entity("AuditDomain.Entity.Violation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("ExplanateOfStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForbidAppliance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalAct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NewFinishedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProposedMeasures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeOfFinished")
                        .HasColumnType("datetime2");

                    b.Property<string>("ViolationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Violations");
                });

            modelBuilder.Entity("AuditDomain.Entity.Audit", b =>
                {
                    b.HasOne("AuditDomain.Entity.Branch", "Branch")
                        .WithMany("Audits")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("AuditDomain.Entity.AuditUser", b =>
                {
                    b.HasOne("AuditDomain.Entity.Audit", "Audit")
                        .WithMany("AuditUser")
                        .HasForeignKey("AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.User", "User")
                        .WithMany("AuditUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuditDomain.Entity.Discrepancy", b =>
                {
                    b.HasOne("AuditDomain.Entity.Audit", "Audit")
                        .WithMany("Discrepancies")
                        .HasForeignKey("AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.Status", "Status")
                        .WithMany("Discrepancys")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("AuditDomain.Entity.IsoDiscrepancy", b =>
                {
                    b.HasOne("AuditDomain.Entity.Discrepancy", "discrepancy")
                        .WithMany("IsoDiscrepancy")
                        .HasForeignKey("DiscrepancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.IsoDirectory", "isoDirectory")
                        .WithMany("IsoDiscrepancy")
                        .HasForeignKey("IsoDirectoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("discrepancy");

                    b.Navigation("isoDirectory");
                });

            modelBuilder.Entity("AuditDomain.Entity.Prescription", b =>
                {
                    b.HasOne("AuditDomain.Entity.Status", "Status")
                        .WithMany("Prescriptions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.Violation", "Violation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("ViolationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Violation");
                });

            modelBuilder.Entity("AuditDomain.Entity.User", b =>
                {
                    b.HasOne("AuditDomain.Entity.Branch", "Branch")
                        .WithMany("users")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.Position", "Position")
                        .WithMany("Users")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.Role", "Role")
                        .WithMany("users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Position");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AuditDomain.Entity.UserViolation", b =>
                {
                    b.HasOne("AuditDomain.Entity.User", "User")
                        .WithMany("UserViolation")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AuditDomain.Entity.Violation", "Violation")
                        .WithMany("UserViolation")
                        .HasForeignKey("ViolationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Violation");
                });

            modelBuilder.Entity("AuditDomain.Entity.Violation", b =>
                {
                    b.HasOne("AuditDomain.Entity.Branch", "Branch")
                        .WithMany("Violations")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("AuditDomain.Entity.Audit", b =>
                {
                    b.Navigation("AuditUser");

                    b.Navigation("Discrepancies");
                });

            modelBuilder.Entity("AuditDomain.Entity.Branch", b =>
                {
                    b.Navigation("Audits");

                    b.Navigation("Violations");

                    b.Navigation("users");
                });

            modelBuilder.Entity("AuditDomain.Entity.Discrepancy", b =>
                {
                    b.Navigation("IsoDiscrepancy");
                });

            modelBuilder.Entity("AuditDomain.Entity.IsoDirectory", b =>
                {
                    b.Navigation("IsoDiscrepancy");
                });

            modelBuilder.Entity("AuditDomain.Entity.Position", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AuditDomain.Entity.Role", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("AuditDomain.Entity.Status", b =>
                {
                    b.Navigation("Discrepancys");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("AuditDomain.Entity.User", b =>
                {
                    b.Navigation("AuditUser");

                    b.Navigation("UserViolation");
                });

            modelBuilder.Entity("AuditDomain.Entity.Violation", b =>
                {
                    b.Navigation("Prescriptions");

                    b.Navigation("UserViolation");
                });
#pragma warning restore 612, 618
        }
    }
}
