using AuditApplication.DTOs.AuditUserDTO;
using AuditApplication.DTOs.DiscrepancyDTO;
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
    public class AuditDTOGet
    {
        public int Id { get; set; }
        public DateTime TimeOfCreating { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeOfAudit TypeOfAudit { get; set; }

        public string GoalOfAudit { get; set; }
        public string StatusName { get; set; }
        public BranchDTO branch { get; set; }

        public ICollection<AuditUserDTOGet> AuditUser { get; set; }
        [JsonIgnore]
        public ICollection<DiscrepancyDTOGet> Discrepancies { get; set; }
    }
}
