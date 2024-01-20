using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string UnitBranch { get; set; }
        public string SubUnitBranch { get; set; }
        public string DepartmentBranch { get; set; }
    }
}
