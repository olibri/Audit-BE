using Audit.Option;
using Audit.TokenService;
using AuditApplication.DTOs.UserDTO;
using AuditDomain.Entity;
using AuditInfrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Audit.Controllers
{
    //Used DbContext class for simplification
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase 
    {       

        private AuditDbContext dbContext;
        private readonly IAuthOption authOption;
        public AccountController(AuditDbContext dbContext, IAuthOption auth)
        {
            this.dbContext = dbContext;
            authOption = auth;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDTOLogin userDTORegistration)
        {
            var user = await dbContext.Users.
                FirstOrDefaultAsync(u => u.Email == userDTORegistration.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userDTORegistration.Password, user.Password) ;

            if (!isPasswordValid)
            {
                return BadRequest("Invalid Password");
            }
            var token = authOption.GenerateJwtToken(user);
            return Ok(new {token = token});
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTORegistration userDTORegistration)
        {
            User? user = await dbContext.Users.FirstOrDefaultAsync(us=>us.Email ==  userDTORegistration.Email);

            if (user == null && ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTORegistration.Password);
                user = new User
                {
                    Email = userDTORegistration.Email,
                    Password = hashedPassword,
                    FullName = userDTORegistration.FullName,
                    Role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Staff"),
                    BranchId = userDTORegistration.BranchId,
                    PositionId = userDTORegistration.PositionId
                };
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
            //var token = authOption.GenerateJwtToken(user);
            return Ok();
        }
  
    }
}
