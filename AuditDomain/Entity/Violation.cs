

namespace AuditDomain.Entity
{
    public class Violation
    {
        public int Id {  get; set; }
        
        public string? ViolationDescription { get; set; }
        public string LegalAct {  get; set; }
        public string? ProposedMeasures { get; set; }
        public DateTime TimeOfFinished { get; set; }

        public string? ExplanateOfStatus { get; set;}
        public DateTime NewFinishedTime { get; set; }
        public string? ForbidAppliance {  get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<UserViolation> UserViolation { get; set; }    
    }
}
