using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.UserDTO;
using AuditDomain.Entity;
using AuditInfrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Audit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMainService<User, UserDTOGet, UserDTOGet> userService;
        public UserController(IMainService<User, UserDTOGet, UserDTOGet> userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> Get()
        {
            var user = await userService.GetExistAsync();
            return Ok(user);
        }         
   
    }
}
