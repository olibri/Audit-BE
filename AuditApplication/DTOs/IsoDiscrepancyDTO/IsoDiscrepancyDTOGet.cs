using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.IsoDiscrepancyDTO
{
    public class IsoDiscrepancyDTOGet
    {
        public int IsoDirectoryId { get; set; }
        public IsoDirectoryDTO isoDirectory { get; set; }
    }
}
