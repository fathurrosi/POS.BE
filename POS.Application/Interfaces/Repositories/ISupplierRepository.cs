using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        List<Supplier> GetByUsername(string username);

        List<Supplier> GetByProfile(string profile);
        //List<Supplier> GetAll(); 
        int Delete(int id);
        int Save(Supplier item);
        Supplier GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetSupplierPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
