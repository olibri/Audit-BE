using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.PrescriptionDTO
{
    public class PrescriptionDTOPost
    {
        [Required]
        public DateTime When_Created { get; set; }
        [Required]
        public DateTime Date_Finished { get; set; }
        [Required(ErrorMessage = "Required more than 10 symbols")]
        public string DescriptionOfPrescription { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int ViolationId { get; set; }
    }
}
