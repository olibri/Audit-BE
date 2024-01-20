using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditDomain.Entity
{
    public class IsoDiscrepancy
    {
        public int Id { get; set; }

        public int IsoDirectoryId { get; set; }
        public virtual IsoDirectory isoDirectory {  get; set; }

        public int DiscrepancyId {  get; set; }
        public virtual Discrepancy discrepancy { get; set; }
    }
}
