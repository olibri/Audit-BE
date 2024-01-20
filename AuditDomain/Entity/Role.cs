

namespace AuditDomain.Entity
{
    public class Role
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> users {  get; set; }   
    }
}
