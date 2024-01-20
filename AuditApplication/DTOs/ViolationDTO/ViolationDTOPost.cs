using AuditApplication.DTOs.UserViolationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.ViolationDTO
{
    public class ViolationDTOPost
    {
        public string? ViolationDescription { get; set; }
        public string LegalAct { get; set; }
        public string? ProposedMeasures { get; set; }
        public DateTime TimeOfFinished { get; set; }

        public string? ExplanateOfStatus { get; set; }
        public DateTime NewFinishedTime { get; set; }
        public string? ForbidAppliance { get; set; }

        public ICollection<UserViolationDTOPost> UserViolation { get; set; }
    }
}
