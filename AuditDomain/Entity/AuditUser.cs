
namespace AuditDomain.Entity
{
    public class AuditUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
