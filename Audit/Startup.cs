using Audit.Option;
using Audit.TokenService;
using AuditApplication;
using AuditApplication.DTOs;
using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.DiscrepancyDTO;
using AuditApplication.DTOs.DTOService;
using AuditApplication.DTOs.PrescriptionDTO;
using AuditApplication.DTOs.StatusService;
using AuditApplication.DTOs.UserDTO;
using AuditApplication.DTOs.ViolationDTO;
using AuditDomain.Entity;
using AuditInfrastructure;
using AuditInfrastructure.Data;
using AuditInfrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Domain = AuditDomain.Entity;

namespace Audit
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration _configuration) {
            configuration = _configuration;
        }    

        public void ConfigureServices(IServiceCollection services)
        {
            var jwtIssuer = configuration.GetSection("Jwt:Issuer").Get<string>();
            var jwtKey = configuration.GetSection("Jwt:Key").Get<string>();
            var key = Encoding.ASCII.GetBytes(jwtKey);

            services.AddDbContext<AuditDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("AuditInfrastructure"))
                .UseLazyLoadingProxies());

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCORS",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = true; // Set True in development
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
            
            services.AddScoped<IRepository<Domain.Audit>, Repository<Domain.Audit>>();
            services.AddScoped<IRepository<Domain.Discrepancy>, Repository<Domain.Discrepancy>>();
            services.AddScoped<IRepository<Domain.Violation>, Repository<Domain.Violation>>();
            services.AddScoped<IRepository<Domain.Prescription>, Repository<Domain.Prescription>>();
            services.AddScoped<IRepository<Domain.User>, Repository<Domain.User>>();
            services.AddScoped<IRepository<Domain.Branch>, Repository<Domain.Branch>>();
            services.AddScoped<IRepository<Domain.IsoDirectory>, Repository<Domain.IsoDirectory>>();
            services.AddScoped<IRepository<Domain.Status>, Repository<Domain.Status>>();
            services.AddScoped<IRepository<Domain.Position>, Repository<Domain.Position>>();


            services.AddScoped<StatusManagerBase<AuditDTOGet>,AuditStatusManager>();
            services.AddScoped<StatusManagerBase<ViolationDTOGet>, ViolationStatusManager>();

            services.AddScoped<IMainService<Domain.Audit, AuditDTOPost, AuditDTOGet>, MainService<Domain.Audit, AuditDTOPost, AuditDTOGet>>();
            services.AddScoped<IMainService<Domain.Discrepancy, DiscrepancyDTOPost, DiscrepancyDTOGet>, MainService<Domain.Discrepancy, DiscrepancyDTOPost, DiscrepancyDTOGet>>();
            services.AddScoped<IMainService<Domain.Violation, ViolationDTOPost, ViolationDTOGet>, MainService<Domain.Violation, ViolationDTOPost, ViolationDTOGet>>();
            services.AddScoped<IMainService<Domain.Prescription, PrescriptionDTOPost, PrescriptionDTOGet>, MainService<Domain.Prescription, PrescriptionDTOPost, PrescriptionDTOGet>>();
            services.AddScoped<IMainService<User, UserDTOGet, UserDTOGet>, MainService<User, UserDTOGet, UserDTOGet>>();
            services.AddScoped<IMainService<Branch, BranchDTO, BranchDTO>, MainService<Branch, BranchDTO, BranchDTO>>();
            services.AddScoped<IMainService<IsoDirectory, IsoDirectoryDTO, IsoDirectoryDTO>, MainService<IsoDirectory, IsoDirectoryDTO, IsoDirectoryDTO>>();
            services.AddScoped<IMainService<Status, StatusDTO,StatusDTO>, MainService<Status, StatusDTO, StatusDTO>>();
            services.AddScoped<IMainService<Position, PositionDTO, PositionDTO>, MainService<Position, PositionDTO, PositionDTO>>();

            services.AddScoped<IAuthOption, AuthOption>();

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); 
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseCors("MyCORS");
            app.UseHttpsRedirection();
            app.UseAuthentication();    
            app.UseAuthorization();

            app.UseEndpoints(endPoint =>
            {
                endPoint.MapControllers();
            });
        }       
    }
}
