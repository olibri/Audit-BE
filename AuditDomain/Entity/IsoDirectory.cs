

namespace AuditDomain.Entity
{
    public class IsoDirectory
    {
        public int Id {  get; set; }
        public int NumberOfISOStandart {  get; set; }
        public string ISOName { get; set; }

        //public int DiscrepancyId {  get; set; }
        public virtual ICollection<IsoDiscrepancy> IsoDiscrepancy { get; set; }
    }
}
