using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {   
        List<Product> GetByProfile(string profile);
        int Delete(string code, string profile);
        int Save(Product item);
        Product GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetProductPagingResult>> GetDataPaging(int pageIndex, int pageSize, string profile);
    }
}
