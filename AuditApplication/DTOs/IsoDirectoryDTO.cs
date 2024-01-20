using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs
{
    public class IsoDirectoryDTO
    {
        public int Id { get; set; }
        public int NumberOfISOStandart { get; set; }
        public string ISOName { get; set; }
    }
}
