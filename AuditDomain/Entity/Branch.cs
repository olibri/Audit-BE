

namespace AuditDomain.Entity
{
    public class Branch
    {
        public int Id {  get; set; }
        public string? UnitBranch {  get; set; }
        public string? SubUnitBranch {  get; set; }
        public string? DepartmentBranch {  get; set; }

        public virtual ICollection<User> users { get; set; }

        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<Violation> Violations { get; set; }
    }
}
