using AuditApplication.DTOs.AuditUserDTO;
using AuditApplication.DTOs.DiscrepancyDTO;
using AuditApplication.DTOs.DTOService;
using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.AuditDTO
{
    public class AuditDTOPost
    {
        [Required]
        public DateTime TimeOfCreating { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeOfAudit TypeOfAudit { get; set; }

        [MinLength(10, ErrorMessage = "Please enter the goal of audit. Required more than 10 symbols")]
        //better create own attribute for checking on spaces
        public string GoalOfAudit { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public ICollection<AuditUserDTOPost> AuditUser { get; set; }

    }
}
