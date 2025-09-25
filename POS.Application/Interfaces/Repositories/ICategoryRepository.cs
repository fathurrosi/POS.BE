//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace POS.Application.Interfaces.Repositories
//{
//    internal interface ICategoryRepository
//    {
//    }
//}

using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetByUsername(string username);

        List<Category> GetByProfile(string profile);
        int Delete(int id);
        int Save(Category item);
        Category GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetCategoryPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
