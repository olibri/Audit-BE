using AuditApplication.DTOs.ViolationDTO;
using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.PrescriptionDTO
{
    public class PrescriptionDTOGet
    {
        public int Id { get; set; }

        public DateTime When_Created { get; set; }
        public DateTime Date_Finished { get; set; }
        public string DescriptionOfPrescription { get; set; }

        public StatusDTO Status { get; set; }

        public ViolationDTOPrescription Violation { get; set; }
    }
}
