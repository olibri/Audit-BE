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
    public class BranchController : ControllerBase
    {
        private readonly IMainService<Branch, BranchDTO, BranchDTO> branchService;
        public BranchController(IMainService<Branch, BranchDTO, BranchDTO> branchService)
        {
            this.branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDTO>>> Get()
        {
            var branch = await branchService.GetExistAsync();
            return Ok(branch);
        }

    }
}
