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
    public class DiscrepancyDTOPost
    {
        [Required]
        public ICollection<IsoDiscrepancyDTOPost> IsoDiscrepancy { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DiscrepancyType DiscrepancyType { get; set; }

        [MinLength(10, ErrorMessage = "Required more than 10 symbols")]
        public string AnotherDiscrepancyRequirements { get; set; }

        [MinLength(10, ErrorMessage = "Required more than 10 symbols")]
        public string DescriptionOfDiscrepancy { get; set; }

        [Required(ErrorMessage = "Choose the date")]
        public DateTime DateOfDetection { get; set; }

      
        public string? ReasonOfDiscrepancy { get; set; }

        [Required(ErrorMessage = "Choose the date")]
        public DateTime DateOfContorolNoticed { get; set; }

        [Required]
        public int AuditId { get; set; }
        [Required]
        public int StatusId { get; set; }


    }
}
