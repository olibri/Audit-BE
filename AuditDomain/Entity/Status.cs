

namespace AuditDomain.Entity
{
    public class Status
    {
        public int Id {  get; set; }

        public string Name { get; set; }

      
        public virtual ICollection<Discrepancy> Discrepancys { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
