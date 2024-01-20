using AuditDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditApplication.DTOs.UserDTO
{
    public class UserDTORegistration
    {     
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$")]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public int BranchId { get; set; }

    }
}
