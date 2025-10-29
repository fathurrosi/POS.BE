using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetByUsername(string username);
        
        List<Role> GetAll(); 
        int Delete(int id);
        int Save(Role item);
        Role GetById(int id);
        Task<PagingResult<Usp_GetRolePagingResult>> GetDataPaging(int pageIndex, int pageSize, string profile);

        Task<List<Usp_GetRoleByProfileResult>> GetRoles(string profile);
    }
}
