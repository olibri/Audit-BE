using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.DiscrepancyDTO;
using AuditInfrastructure.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain = AuditDomain.Entity;

namespace Audit.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DiscrepancyController : ControllerBase
    {
        IMainService<Domain.Discrepancy, DiscrepancyDTOPost, DiscrepancyDTOGet> discrepancyService;
        public DiscrepancyController(IMainService<Domain.Discrepancy, DiscrepancyDTOPost, DiscrepancyDTOGet> subServiceTest)
        {
            discrepancyService = subServiceTest;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscrepancyDTOGet>>> Get()
        {
            return Ok(await discrepancyService.GetExistAsync());
        }

        [HttpGet]
        [Route("Sort")]
        public async Task<ActionResult<IEnumerable<DiscrepancyDTOGet>>> GetSorted()
        {
            var audits = await discrepancyService.GetSortedValuesAsync(p => p.DateOfDetection);
            return Ok(audits);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DiscrepancyDTOPost>> Post(DiscrepancyDTOPost discrepancyDTOPost)
        {
            await discrepancyService.CreateNew(discrepancyDTOPost);
            return RedirectToAction(nameof(Get));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<DiscrepancyDTOPost>> Put(int id, DiscrepancyDTOPost discrepancyDTOPost)
        {
            var res = await discrepancyService.UpdateExist(id, discrepancyDTOPost);
            if (res == null)
                return NotFound("Discrepancy not found");
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiscrepancyDTOPost>> Delete(int id)
        {
            var result = await discrepancyService.DeleteExist(id);  
            if(!result) 
                return NotFound("Discrepancy not found");
            return Ok();
        }
    }
}
