using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditDomain.Entity
{
    public class UserViolation
    {
        public int Id { get; set; }
        public int ViolationId { get; set; }
        public virtual Violation Violation { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }  
    }
}
