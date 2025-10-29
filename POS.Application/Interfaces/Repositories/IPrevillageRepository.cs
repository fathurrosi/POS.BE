using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IPrevillageRepository
    {
        public Task<List<VUserPrevillage>> GetByUsername(string username);
        public Task<List<Usp_GetPrevillageByProfileRoleResult>> GetByProfileRole(string profile, int role);
        public Task<object> Save(List<VRolePrevillage> items);
    }
}
