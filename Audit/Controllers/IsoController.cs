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
    public class IsoController : ControllerBase
    {
        IMainService<IsoDirectory, IsoDirectoryDTO, IsoDirectoryDTO> isoService;
        public IsoController(IMainService<IsoDirectory, IsoDirectoryDTO, IsoDirectoryDTO> isoService)
        {
            this.isoService = isoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IsoDirectoryDTO>>> Get()
        {
            var iso = await isoService.GetExistAsync();
            return Ok(iso);
        }
    }
}
