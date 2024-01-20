using Audit.Controllers;
using Audit.TokenService;
using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.UserDTO;
using AuditDomain.Entity;
using AuditInfrastructure.Data;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using System.Text.Json;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuditTest
{
    public class AccountControllerTests
    {
        private readonly AccountController accountController;
        private readonly AuditDbContext auditDbContext;

        private readonly Mock<IAuthOption> mockAuthOption;
        public AccountControllerTests()
        {
            var option = new DbContextOptionsBuilder<AuditDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            auditDbContext = new AuditDbContext(option);
            mockAuthOption = new Mock<IAuthOption>();
            mockAuthOption.Setup(x => x.GenerateJwtToken(It.IsAny<User>())).Returns("test_token");

            accountController = new AccountController(auditDbContext, mockAuthOption.Object);
        }

        [Fact]
        public async Task CreateAccount_ReturnsOk_WhenNewUser()
        {
            var newUser = new Fixture().Create<UserDTORegistration>();

            var result = await accountController.Register(newUser);
            var okResult = Assert.IsType<OkObjectResult>(result);
            string a = JsonConvert.SerializeObject(okResult.Value);
            var test = JsonConvert.DeserializeObject<dynamic>(a);
            var token = test.token.Value;
            Assert.Equal("test_token", token);

            var createdUser = await auditDbContext.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
            Assert.NotNull(createdUser);
            Assert.Equal(newUser.Email, createdUser.Email);
            Dispose();

        }
        [Fact]
        public async Task LoginAccount_ReturnsOk()
        {
            var newUser = new Fixture().Create<UserDTOLogin>();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            auditDbContext.Users.Add(new User { 
                Email = newUser.Email,
                Password = hashedPassword,
                PositionId = 1,
                FullName = "Ivan Ivanovich",
                RoleId= 1,
                BranchId = 5,
            });
            await auditDbContext.SaveChangesAsync();

            var result = await accountController.Login(newUser);
            var okResult = Assert.IsType<OkObjectResult>(result);
            string a = JsonConvert.SerializeObject(okResult.Value);
            var test = JsonConvert.DeserializeObject<dynamic>(a);
            var token = test.token.Value;
            Assert.Equal("test_token", token);

            var loginedUser = await auditDbContext.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
            Assert.NotNull(loginedUser);
            Assert.Equal(newUser.Email, loginedUser.Email);

            Dispose();
        }
        [Fact]
        public async Task LoginAccount_WrongPassword()
        {
            var newUser = new Fixture().Create<UserDTOLogin>();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("HelloWorld");
            auditDbContext.Users.Add(new User
            {
                Email = newUser.Email,
                Password = hashedPassword,
                PositionId = 1,
                FullName = "Ivan Ivanovich",
                RoleId = 1,
                BranchId = 5,
            });
            await auditDbContext.SaveChangesAsync();
            var result = await accountController.Login(newUser);
            Assert.IsType<BadRequestObjectResult>(result);
            Dispose();
        }   
        [Fact]
        public async Task LoginAccount_UserNotFound()
        {
            var newUser = new Fixture().Create<UserDTOLogin>();
            var result = await accountController.Login(newUser);
            Assert.IsType<BadRequestObjectResult>(result);
            Dispose();
        }
        private void Dispose()
        {
            auditDbContext.Database.EnsureDeleted();
            auditDbContext.Dispose();
        }
    }
}
