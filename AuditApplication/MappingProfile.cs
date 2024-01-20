using AuditApplication.DTOs;
using AuditApplication.DTOs.AuditDTO;
using AuditApplication.DTOs.AuditUserDTO;
using AuditApplication.DTOs.DiscrepancyDTO;
using AuditApplication.DTOs.IsoDiscrepancyDTO;
using AuditApplication.DTOs.PrescriptionDTO;
using AuditApplication.DTOs.UserDTO;
using AuditApplication.DTOs.UserViolationDTO;
using AuditApplication.DTOs.ViolationDTO;
using AuditDomain.Entity;
using AutoMapper;


namespace AuditApplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Audit, AuditDTOPost>().ReverseMap();
            CreateMap<Audit, AuditDTOGet>().ReverseMap();

            CreateMap<Discrepancy, DiscrepancyDTOPost>().ReverseMap();
            CreateMap<Discrepancy, DiscrepancyDTOGet>().ReverseMap();

    
            CreateMap<Violation, ViolationDTOGet>().ReverseMap();
            CreateMap<Violation, ViolationDTOPost>().ReverseMap();

            //CreateMap<Violation, ViolationDTOPrescription>().ReverseMap();
            CreateMap<Prescription, PrescriptionDTOGet>().ReverseMap();
            CreateMap<Prescription, PrescriptionDTOPost>().ReverseMap();

            CreateMap<IsoDirectory, IsoDirectoryDTO>().ReverseMap();

            CreateMap<AuditUser, AuditUserDTOPost>().ReverseMap();
            CreateMap<AuditUser, AuditUserDTOGet>().ReverseMap();
            CreateMap<UserViolation, UserViolationDTOPost>().ReverseMap();
            CreateMap<UserViolation, UserViolationDTOGet>().ReverseMap();
            CreateMap<IsoDiscrepancy, IsoDiscrepancyDTOPost>().ReverseMap();
            CreateMap<IsoDiscrepancy, IsoDiscrepancyDTOGet>().ReverseMap();


            CreateMap<User, UserDTOLogin>().ReverseMap();
            CreateMap<User, UserDTORegistration>().ReverseMap();
            CreateMap<User, UserDTOGet>().ReverseMap();

            CreateMap<Branch, BranchDTO>().ReverseMap();
            CreateMap<IsoDirectory, IsoDirectoryDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            
        }
    }
}
