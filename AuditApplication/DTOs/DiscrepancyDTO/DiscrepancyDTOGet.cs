using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.IsoDiscrepancyDTO;
using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.DiscrepancyDTO
{
    public class DiscrepancyDTOGet
    {
        public int Id { get; set; }
        public ICollection<IsoDiscrepancyDTOGet> IsoDiscrepancy { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DiscrepancyType DiscrepancyType { get; set; }

        public string AnotherDiscrepancyRequirements { get; set; }

        public string DescriptionOfDiscrepancy { get; set; }

        public DateTime DateOfDetection { get; set; }

        public string? ReasonOfDiscrepancy { get; set; }

        public DateTime DateOfContorolNoticed { get; set; }

        public StatusDTO Status { get; set; }
        public int AuditId { get; set; }
        //public AuditDTODiscrepancy Audit { get; set; }
    }
}
