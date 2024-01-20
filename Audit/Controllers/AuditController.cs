using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.DTOService;
using AuditApplication.DTOs.StatusService;
using AuditDomain.Entity;
using AuditInfrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain = AuditDomain.Entity;
namespace Audit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class AuditController : ControllerBase
    {
        IMainService<Domain.Audit, AuditDTOPost, AuditDTOGet> auditService;
        //IStatusManager<AuditDTOGet> _statusManager;
        private readonly StatusManagerBase<AuditDTOGet> statusManager;

        public AuditController(IMainService<Domain.Audit, AuditDTOPost, AuditDTOGet> auditService, StatusManagerBase<AuditDTOGet> statusManager)
        {
            this.auditService = auditService;
            this.statusManager = statusManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditDTOGet>>> Get()
        {
            var audits = await auditService.GetExistAsync();
            audits = statusManager.UpdateStatus(audits);
            return Ok(audits);
        }
        [HttpGet]
        [Route("Sort")]
        public async Task<ActionResult<IEnumerable<AuditDTOGet>>> GetSorted()
        {
            var audits = await auditService.GetSortedValuesAsync(p=>p.BranchId);
            return Ok(audits);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AuditDTOPost>> Post(AuditDTOPost auditDTO)
        {
            await auditService.CreateNew(auditDTO); 
            return RedirectToAction(nameof(Get));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<AuditDTOPost>> Put(int id, AuditDTOPost auditDTO)
        {
            var audits = await auditService.GetById(id);
            statusManager.UpdateStatusForSingleItem(audits);

            if (statusManager.CheckStatus)
                return BadRequest("U can't edit this Audit. Status closed");

            var res = await auditService.UpdateExist(id, auditDTO);
            if (res == null)
                return NotFound("Audit not found"); 
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuditDTOPost>> Delete(int id)
        {
            if (statusManager.CheckStatus)
                return BadRequest("U can't delete this Audit. Status closed");
            var result =  await auditService.DeleteExist(id);
            if (!result) 
                 return NotFound("Audit not found");
            return Ok();
        }
    }
}
