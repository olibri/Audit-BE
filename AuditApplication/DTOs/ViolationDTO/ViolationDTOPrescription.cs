using AuditApplication.DTOs.AuditUserDTO;
using AuditApplication.DTOs.UserViolationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.ViolationDTO
{
    public class ViolationDTOPrescription
    {
        public int Id { get; set; }
        public BranchDTO Branch { get; set; }
        public ICollection<UserViolationDTOGet> User { get; set; }
    }
}
