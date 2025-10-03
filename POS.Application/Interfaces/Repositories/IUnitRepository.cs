
using POS.Domain.Entities;
using POS.Domain.Models.Result;


namespace POS.Application.Interfaces.Repositories
{
    public interface IUnitRepository
    {
        List<Unit> GetByUsername(string username);

        List<Unit> GetByProfile(string profile);
        int Delete(string code, string profile);
        int Save(Unit item);
        Unit GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetUnitPagingResult>> GetDataPaging(int pageIndex, int pageSize, string profile);
    }
}
