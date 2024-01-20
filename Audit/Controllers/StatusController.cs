using AuditApplication.DTOs;
using AuditApplication.DTOs.UserDTO;
using AuditDomain.Entity;
using AuditInfrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        IMainService<Status, StatusDTO, StatusDTO> statusService;
        public StatusController(IMainService<Status, StatusDTO, StatusDTO> statusService)
        {
            this.statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IsoDirectoryDTO>>> Get()
        {
            var status = await statusService.GetExistAsync();
            return Ok(status);
        }
    }
}
