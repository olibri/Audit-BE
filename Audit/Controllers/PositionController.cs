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
    public class PositionController : ControllerBase
    {
        IMainService<Position, PositionDTO, PositionDTO> positionService;

        public PositionController(IMainService<Position, PositionDTO, PositionDTO> _positionService) { 
            this.positionService = _positionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDTO>>> Get()
        {
            var user = await positionService.GetExistAsync();
            return Ok(user);
        }


    }
}
