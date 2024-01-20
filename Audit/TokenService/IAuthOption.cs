using AuditDomain.Entity;

namespace Audit.TokenService
{
    public interface IAuthOption
    {
        public string GenerateJwtToken(User user);
    }
}
