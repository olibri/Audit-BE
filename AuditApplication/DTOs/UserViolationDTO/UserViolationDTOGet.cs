using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditApplication.DTOs.UserDTO;

namespace AuditApplication.DTOs.UserViolationDTO
{
    public class UserViolationDTOGet
    {
        public int UserId { get; set; }
        public UserDTOLogin User { get; set; }
    }
}
