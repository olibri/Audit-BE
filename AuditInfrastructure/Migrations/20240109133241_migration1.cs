using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubUnitBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentBranch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsoDirectories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfISOStandart = table.Column<int>(type: "int", nullable: false),
                    ISOName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsoDirectories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfPosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfCreating = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfAudit = table.Column<int>(type: "int", nullable: false),
                    GoalOfAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViolationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalAct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposedMeasures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfFinished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExplanateOfStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewFinishedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForbidAppliance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Violations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discrepancys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscrepancyType = table.Column<int>(type: "int", nullable: false),
                    AnotherDiscrepancyRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfDiscrepancy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDetection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonOfDiscrepancy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfContorolNoticed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AuditId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discrepancys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discrepancys_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discrepancys_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Finished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescriptionOfPrescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ViolationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuditId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditUsers_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserViolations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViolationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserViolations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserViolations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserViolations_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IsoDiscrepancy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoDirectoryId = table.Column<int>(type: "int", nullable: false),
                    DiscrepancyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsoDiscrepancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsoDiscrepancy_Discrepancys_DiscrepancyId",
                        column: x => x.DiscrepancyId,
                        principalTable: "Discrepancys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsoDiscrepancy_IsoDirectories_IsoDirectoryId",
                        column: x => x.IsoDirectoryId,
                        principalTable: "IsoDirectories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audits_BranchId",
                table: "Audits",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditUsers_AuditId",
                table: "AuditUsers",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditUsers_UserId",
                table: "AuditUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancys_AuditId",
                table: "Discrepancys",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancys_StatusId",
                table: "Discrepancys",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IsoDiscrepancy_DiscrepancyId",
                table: "IsoDiscrepancy",
                column: "DiscrepancyId");

            migrationBuilder.CreateIndex(
                name: "IX_IsoDiscrepancy_IsoDirectoryId",
                table: "IsoDiscrepancy",
                column: "IsoDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_StatusId",
                table: "Prescriptions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ViolationId",
                table: "Prescriptions",
                column: "ViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViolations_UserId",
                table: "UserViolations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViolations_ViolationId",
                table: "UserViolations",
                column: "ViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_BranchId",
                table: "Violations",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditUsers");

            migrationBuilder.DropTable(
                name: "IsoDiscrepancy");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "UserViolations");

            migrationBuilder.DropTable(
                name: "Discrepancys");

            migrationBuilder.DropTable(
                name: "IsoDirectories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
