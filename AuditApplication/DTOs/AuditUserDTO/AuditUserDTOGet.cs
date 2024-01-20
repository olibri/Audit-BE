using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditApplication.DTOs.UserDTO;

namespace AuditApplication.DTOs.AuditUserDTO
{
    public class AuditUserDTOGet //Update in v2.0. Delete this one and use GraphQl
    {
        public int UserId { get; set; }
        public UserDTOLogin user { get; set; }
    }
}
