using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetByUsername(string username);

        List<Category> GetByProfile(string profile);
        int Delete(string code, string profile);
        int Save(Category item);
        Category GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetCategoryPagingResult>> GetDataPaging(int pageIndex, int pageSize, string profile);
    }
}
