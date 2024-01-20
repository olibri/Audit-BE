using AuditApplication.DTOs.PrescriptionDTO;
using AuditApplication.DTOs.UserViolationDTO;
using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.ViolationDTO
{
    public class ViolationDTOGet
    {
        public int Id { get; set; }

        public string? ViolationDescription { get; set; }
        public string LegalAct { get; set; }
        public string? ProposedMeasures { get; set; }
        public DateTime TimeOfFinished { get; set; }

        public string? ExplanateOfStatus { get; set; }
        public DateTime NewFinishedTime { get; set; }
        public string? ForbidAppliance { get; set; }

        public string StatusName { get; set; }

        public ICollection<UserViolationDTOGet> UserViolation { get; set; }
        public ICollection<PrescriptionDTOGet> Prescriptions { get; set; }
    }
}
