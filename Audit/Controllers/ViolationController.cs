using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.DTOService;
using AuditApplication.DTOs.StatusService;
using AuditApplication.DTOs.ViolationDTO;
using AuditDomain.Entity;
using AuditInfrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Audit.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        IMainService<Violation, ViolationDTOPost, ViolationDTOGet> violationService;
        private readonly StatusManagerBase<ViolationDTOGet> statusManager;
        public ViolationController(IMainService<Violation, ViolationDTOPost, ViolationDTOGet> mainService, StatusManagerBase<ViolationDTOGet> statusManager)
        {
            this.statusManager = statusManager;
            violationService = mainService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViolationDTOGet>>> Get()
        {
            var violation = await violationService.GetExistAsync();
            violation = statusManager.UpdateStatus(violation);
            return Ok(violation);
        }
        [HttpGet]
        [Route("Sort")]
        public async Task<ActionResult<IEnumerable<AuditDTOGet>>> GetSorted()
        {
            var audits = await violationService.GetSortedValuesAsync(p => p.TimeOfFinished);
            return Ok(audits);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ViolationDTOPost>> Post(ViolationDTOPost violationDTO)
        {
            await violationService.CreateNew(violationDTO);
            return RedirectToAction(nameof(Get));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<ViolationDTOPost>> Put(int id, ViolationDTOPost violationDTO)
        {
            if (!statusManager.CheckStatus)
                return BadRequest("U can't edit this Violation. Status closed");

            var res = await violationService.UpdateExist(id, violationDTO);
            if (res == null)
                return NotFound("Violation not found");
            
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViolationDTOPost>> Delete(int id)
        {
            if (!statusManager.CheckStatus)
                return BadRequest("U can't delete this Violation. Status closed");
            var result = await violationService.DeleteExist(id);
            if (!result)
                return NotFound("Violation not found.");
            return Ok();
        }
    }
}
