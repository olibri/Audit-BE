using AuditDomain.Entity;
using AuditInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuditInfrastructure.Entity
{
    public class SeedData
    {
        public static void Initialization(AuditDbContext auditDbContext)
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Auditor" },
                new Role { Name = "Staff" }
            };
            auditDbContext.Roles.AddRange(roles);
            auditDbContext.SaveChanges();

            var positions = new List<Position>
            {
                new Position { NameOfPosition = "Manager" },
                new Position { NameOfPosition = "Supervisor" },
                new Position { NameOfPosition = "Worker" }
            };
            auditDbContext.Positions.AddRange(positions);
            auditDbContext.SaveChanges();

            var statuses = new List<Status>
            {
                new Status {  Name = "Open" },
                new Status {  Name = "In Progress" },
                new Status {  Name = "Closed"}
            };
            auditDbContext.Status.AddRange(statuses);
            auditDbContext.SaveChanges();

            var branches = new List<Branch>
            {
                new Branch { UnitBranch = "Unit1", SubUnitBranch = "SubUnitA", DepartmentBranch = "DeptX" },
                new Branch { UnitBranch = "Unit2", SubUnitBranch = "SubUnitB", DepartmentBranch = "DeptY" },
                new Branch { UnitBranch = "Unit3", SubUnitBranch = "SubUnitC", DepartmentBranch = "DeptZ" }
            };
            auditDbContext.Branches.AddRange(branches);
            auditDbContext.SaveChanges();

            var users = new List<User>
            {
                new User {  FullName = "John Doe", Email = "john.doe@example.com", Password = "password123", PositionId = 1, BranchId = 1, RoleId = 1 },
                new User {  FullName = "Jane Smith", Email = "jane.smith@example.com", Password = "password123", PositionId = 2, BranchId = 2, RoleId = 2 },
                new User {  FullName = "Bob Johnson", Email = "bob.johnson@example.com", Password = "password123", PositionId = 3, BranchId = 3, RoleId = 3 }
            };
            auditDbContext.Users.AddRange(users);
            auditDbContext.SaveChanges();


            var audits = new List<Audit>
            {
                new Audit{  TimeOfCreating = DateTime.Now.Date, TypeOfAudit = TypeOfAudit.Scheduled, GoalOfAudit = "Safety Standards Compliance", BranchId = 1 },
                new Audit {  TimeOfCreating = DateTime.Now.AddDays(-10).Date, TypeOfAudit = TypeOfAudit.Unscheduled, GoalOfAudit = "Emergency Inspection", BranchId = 2 },
                new Audit {  TimeOfCreating = DateTime.Now.AddDays(-20).Date, TypeOfAudit = TypeOfAudit.Scheduled, GoalOfAudit = "Routine Financial Audit", BranchId = 1 }
            };
            auditDbContext.Audits.AddRange(audits);
            auditDbContext.SaveChanges();

            var auditUser = new List<AuditUser>
            {
                new AuditUser{ AuditId=1, UserId= 1 },
                new AuditUser{ AuditId=2, UserId= 2 },
                new AuditUser{ AuditId=3, UserId= 3 },
            };
            auditDbContext.AuditUsers.AddRange(auditUser);
            auditDbContext.SaveChanges();

            var discrepancies = new List<Discrepancy>
            {
                new Discrepancy { DiscrepancyType = DiscrepancyType.Essential, DescriptionOfDiscrepancy = "Fire exit blocked", DateOfDetection = DateTime.Now.Date, StatusId= 1, AuditId = 1},
                new Discrepancy { DiscrepancyType = DiscrepancyType.Insignificant, DescriptionOfDiscrepancy = "Minor electrical issue", DateOfDetection = DateTime.Now.AddDays(-1).Date,StatusId=2 ,AuditId = 2 },
                new Discrepancy { DiscrepancyType = DiscrepancyType.Essential, DescriptionOfDiscrepancy = "Lack of safety equipment", DateOfDetection = DateTime.Now.AddDays(-2).Date, StatusId = 2, AuditId = 3 }
            };
            auditDbContext.Discrepancys.AddRange(discrepancies);
            auditDbContext.SaveChanges();
            
            var isoDirectories = new List<IsoDirectory>
            {
                new IsoDirectory {  NumberOfISOStandart = 9001, ISOName = "Quality Management" },
                new IsoDirectory {  NumberOfISOStandart = 14001, ISOName = "Environmental Management"},
                new IsoDirectory {  NumberOfISOStandart = 45001, ISOName = "Occupational Health and Safety" }
            };
            auditDbContext.IsoDirectories.AddRange(isoDirectories);
            auditDbContext.SaveChanges();


            var violations = new List<Violation>
            {
                new Violation {  ViolationDescription = "Breach of safety protocol", LegalAct = "Safety Act", ProposedMeasures = "Training", TimeOfFinished = DateTime.Now.AddDays(30).Date , BranchId = 1},
                new Violation {  ViolationDescription = "Environmental contamination", LegalAct = "Environment Act", ProposedMeasures = "Cleanup", TimeOfFinished = DateTime.Now.AddDays(60).Date, BranchId = 2 },
                new Violation {  ViolationDescription = "Financial discrepancy", LegalAct = "Finance Act", ProposedMeasures = "Audit", TimeOfFinished = DateTime.Now.AddDays(90).Date , BranchId = 1}
            };
            auditDbContext.Violations.AddRange(violations);
            auditDbContext.SaveChanges();


            var violationUser = new List<UserViolation>
            {
                new UserViolation{ ViolationId= 1, UserId=1 },
                new UserViolation { ViolationId = 2, UserId = 2 },
                new UserViolation { ViolationId = 3, UserId = 3 },
            };
            auditDbContext.UserViolations.AddRange(violationUser);
            auditDbContext.SaveChanges();

            var prescriptions = new List<Prescription>
            {
                new Prescription { When_Created = DateTime.Now.Date, Date_Finished = DateTime.Now.AddDays(30).Date ,StatusId=1, ViolationId = 1, DescriptionOfPrescription ="stringstr1" },
                new Prescription { When_Created = DateTime.Now.AddDays(-1).Date, Date_Finished = DateTime.Now.AddDays(-1).AddDays(29).Date,StatusId=1,ViolationId = 2, DescriptionOfPrescription = "stringstr2" },
                new Prescription { When_Created = DateTime.Now.AddDays(-2).Date, Date_Finished = DateTime.Now.AddDays(-2).AddDays(28).Date,StatusId=3,ViolationId = 3, DescriptionOfPrescription = "stringstr3"}
            };
            auditDbContext.Prescriptions.AddRange(prescriptions);
            auditDbContext.SaveChanges();

            var isoDiscrepancy = new List<IsoDiscrepancy>
            {
                new IsoDiscrepancy {IsoDirectoryId=1, DiscrepancyId=1},
                new IsoDiscrepancy{ IsoDirectoryId=2, DiscrepancyId =2},
                new IsoDiscrepancy {IsoDirectoryId=3, DiscrepancyId=3},
            };

            auditDbContext.IsoDiscrepancy.AddRange(isoDiscrepancy);
            auditDbContext.SaveChanges();

            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO AuditUser (userId, AuditId) VALUES (3, 3)");
            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO AuditUser (userId, AuditId) VALUES (1, 1)");
            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO AuditUser (userId, AuditId) VALUES (2, 2)");

            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO UserViolation (ViolationId ,userId ) VALUES (2, 2)");
            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO UserViolation (ViolationId ,userId ) VALUES (3, 3)");
            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO UserViolation (ViolationId ,userId ) VALUES (1, 1)");

            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO IsoDiscrepancy (IsoDirectoryId, DiscrepancyId) VALUES (1, 2)");
            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO IsoDiscrepancy (IsoDirectoryId, DiscrepancyId) VALUES (2, 3)");
            auditDbContext.Database.ExecuteSqlRaw("INSERT INTO IsoDiscrepancy (IsoDirectoryId, DiscrepancyId) VALUES (1, 1)");

            auditDbContext.SaveChanges();



        }
    }
}
