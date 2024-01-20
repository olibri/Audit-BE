
namespace AuditDomain.Entity
{
    public class Position
    {
        public int Id {  get; set; }
        public string? NameOfPosition { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
