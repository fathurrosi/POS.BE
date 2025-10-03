using Microsoft.Data.SqlClient;
using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Application.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        List<Menu> GetAll();
        List<Menu> GetByUsername(string username);
        Menu GetById(int id);
        public Task<PagingResult<Usp_GetMenuPagingResult>> GetDataPaging(int pageIndex, int pageSize);
        
        int Save(Menu item);
        int Delete(int id);

    }
}
