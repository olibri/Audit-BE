using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.DiscrepancyDTO;
using AuditApplication.DTOs.PrescriptionDTO;
using AuditDomain.Entity;
using AuditInfrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audit.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        IMainService<Prescription, PrescriptionDTOPost, PrescriptionDTOGet> prescriptionService;
        public PrescriptionController(IMainService<Prescription, PrescriptionDTOPost, PrescriptionDTOGet> prescriptionService)
        {
            this.prescriptionService = prescriptionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescriptionDTOGet>>> Get()
        {
            return Ok(await prescriptionService.GetExistAsync());
        }
        [HttpGet]
        [Route("Sort")]
        public async Task<ActionResult<IEnumerable<PrescriptionDTOGet>>> GetSorted()
        {
            var audits = await prescriptionService.GetSortedValuesAsync(p => p.StatusId);
            return Ok(audits);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PrescriptionDTOPost>> Post(PrescriptionDTOPost prescriptionDTOPost)
        {
            await prescriptionService.CreateNew(prescriptionDTOPost);
            return RedirectToAction(nameof(Get));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<PrescriptionDTOPost>> Put(int id, PrescriptionDTOPost precriptionDTOPost)
        {
            var res = await prescriptionService.UpdateExist(id, precriptionDTOPost);
            if (res == null)
                return NotFound("Prescription not found");
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrescriptionDTOPost>> Delete(int id)
        {
            var result = await prescriptionService.DeleteExist(id);
            if (!result)
                return NotFound("Prescription not found");
            return Ok();
        }
    }
}
