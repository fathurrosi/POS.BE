using POS.Domain.Entities;
using POS.Domain.Models.Response;

namespace POS.Application.Interfaces.Services
{
    public interface IJwtService
    {
        public LoginResponse<User> Authenticate(Domain.Models.Request.LoginRequest request);
    }
}
