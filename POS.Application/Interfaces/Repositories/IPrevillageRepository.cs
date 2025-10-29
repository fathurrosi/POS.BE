using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IPrevillageRepository
    {
        //public Task<List<Usp_GetPrevillageByUsernameResult>> GetByUsername(string username);
        public Task<List<VUserPrevillage>> GetByUsername(string username);
        //public List<VUserPrevillage> GetByProfile(string profile);
        //public List<VUserPrevillage> GetByProfileRole(string profile, int role);
        public Task<List<Usp_GetPrevillageByProfileRoleResult>> GetByProfileRole(string profile, int role);
    }
}
