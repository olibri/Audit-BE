using AuditInfrastructure.Data;
using Audit.Option;
using Moq;
using Audit.Controllers;
using AuditApplication.DTOs.UserDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Audit.TokenService;
using AuditInfrastructure.Service;
using AuditApplication.DTOs.AuditDTO;
using Domain = AuditDomain.Entity;
using AuditApplication.DTOs.DTOService;
using AuditDomain.Entity;
using AuditApplication.DTOs.AuditUserDTO;
using AuditApplication.DTOs;
using AutoFixture;

namespace AuditTest
{
    public class AuditControllerTest
    {      
        private readonly Mock<IMainService<Domain.Audit, AuditDTOPost, AuditDTOGet>> mockContext;
        private readonly Mock<IStatusManager<AuditDTOGet>> mockAuthOption;
        private readonly AuditController controller;
        public AuditControllerTest()
        {    
            mockContext = new Mock<IMainService<Domain.Audit, AuditDTOPost, AuditDTOGet>>();
            mockAuthOption = new Mock<IStatusManager<AuditDTOGet>>();    
            controller = new AuditController(mockContext.Object, mockAuthOption.Object);
        }

        [Fact]
        public async Task Audit_Get()
        {
            var testAudit = new Fixture().Create<AuditDTOGet>();
            var testAuditList = new List<AuditDTOGet> { testAudit };

            mockAuthOption.Setup(m => m.UpdateStatus(It.IsAny<IEnumerable<AuditDTOGet>>()))
              .Returns((IEnumerable<AuditDTOGet> audits) => audits);  

            mockContext.Setup(repo => repo.GetExistAsync()).
                ReturnsAsync(testAuditList);

            var result = await controller.Get();
            var actionResult=  Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<AuditDTOGet>>(actionResult.Value);
            Assert.NotEmpty(returnValue);
        }
        [Fact]
        public async Task Audit_GetSorted()
        {
            var testAudit = new Fixture().Create<AuditDTOGet>();
            var testAuditList = new List<AuditDTOGet> { testAudit };    
            
            mockContext.Setup(repo => repo.GetSortedValuesAsync(p=>p.BranchId)).
                ReturnsAsync(testAuditList);
            
            var result = await controller.GetSorted();
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<AuditDTOGet>>(actionResult.Value);
            Assert.NotEmpty(returnValue);
        }
        [Fact]
        public async Task Audit_Post()
        {
            var testAuditPost = new Fixture().Create<AuditDTOPost>();
            mockContext.Setup(repo => repo.CreateNew(It.IsAny<AuditDTOPost>())).
                ReturnsAsync(testAuditPost);
            var result = await controller.Post(testAuditPost);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result.Result);
            Assert.Equal("Get", redirectToActionResult.ActionName); 
        }
        [Fact]
        public async Task Audit_Put_OkResult()
        {
            var testAuditPost = new Fixture().Create<AuditDTOPost>();
            mockContext.Setup(repo => repo.UpdateExist(1, testAuditPost)).
                ReturnsAsync(testAuditPost);
            var result = await controller.Put(1, testAuditPost);
            Assert.IsType<OkResult>(result.Result);
        }
        [Fact]
        public async Task Audit_Put_NotFoundResult()
        {
            var testAuditPost = new Fixture().Create<AuditDTOPost>();
            mockContext.Setup(repo => repo.UpdateExist(0, testAuditPost)).
                ReturnsAsync((AuditDTOPost)null);

            var result = await controller.Put(1, testAuditPost);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Audit not found", notFoundResult.Value);
        }
        [Fact]
        public async Task Audit_Delete_OkResult()
        {
            mockContext.Setup(repo => repo.DeleteExist(1)).
                ReturnsAsync(true);

            var result = await controller.Delete(1);
            Assert.IsType<OkResult>(result.Result);
        } 
        [Fact]
        public async Task Audit_Delete_NotFoundResult()
        {
            mockContext.Setup(repo => repo.DeleteExist(1)).
                ReturnsAsync(false);
            var result = await controller.Delete(1);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Audit not found", notFoundResult.Value);
        }

    }
}