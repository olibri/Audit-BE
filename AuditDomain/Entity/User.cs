
namespace AuditDomain.Entity
{
    public class User
    {
        public int Id { get; set; } 
        public string? FullName { get; set; }

        public string Email {  get; set; }
        public string Password {  get; set; }

        public int PositionId { get; set; }
        public  virtual Position Position { get; set; }

        public int BranchId {  get; set; }
        public virtual Branch Branch { get; set; }

        public int RoleId {  get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<AuditUser>? AuditUser { get; set; }
        public virtual ICollection<UserViolation>? UserViolation { get; set; }
    }
}
