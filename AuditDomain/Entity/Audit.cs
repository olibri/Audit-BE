namespace AuditDomain.Entity
{
    public enum TypeOfAudit
    {
        Unscheduled= 0,
        Scheduled = 1
    }
   
    public class Audit
    {
        public int Id {  get; set; }
        public DateTime TimeOfCreating { get; set; } 
        public TypeOfAudit TypeOfAudit { get; set; }
        public string? GoalOfAudit { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<Discrepancy> Discrepancies { get; set; }
        public virtual ICollection<AuditUser> AuditUser { get; set; }
    }
}
