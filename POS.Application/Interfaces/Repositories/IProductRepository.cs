using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetByUsername(string username);
        
        List<Product> GetByProfile(string profile);
        int Delete(int id);
        int Save(Product item);
        Product GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetProductPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
