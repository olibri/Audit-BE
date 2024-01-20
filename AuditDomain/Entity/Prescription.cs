
namespace AuditDomain.Entity
{
    public class Prescription
    {
        public int Id { get; set; }
       
        public DateTime When_Created { get; set; }
        public DateTime Date_Finished { get; set; }
        public string DescriptionOfPrescription { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int ViolationId { get; set; }
        public virtual Violation? Violation { get; set; }
    }
}
