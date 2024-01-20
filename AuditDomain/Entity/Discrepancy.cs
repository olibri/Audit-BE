

namespace AuditDomain.Entity
{
    public enum DiscrepancyType {
        Essential,
        Insignificant
    }

    public class Discrepancy
    {
        public int Id {  get; set; }

        public virtual ICollection<IsoDiscrepancy> IsoDiscrepancy { get; set; }

        public DiscrepancyType DiscrepancyType { get; set;}
        public string? AnotherDiscrepancyRequirements {  get; set; }
        public string? DescriptionOfDiscrepancy { get; set; }
        public DateTime DateOfDetection { get; set; }
        public string? ReasonOfDiscrepancy { get; set; }
        public DateTime DateOfContorolNoticed {  get; set; }

        public int StatusId {  get; set; }
        public virtual Status Status { get; set; }

        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
