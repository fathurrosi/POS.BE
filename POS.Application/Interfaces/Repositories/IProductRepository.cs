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
        List<Catalog> GetByUsername(string username);
        
        List<Product> GetAll(); 
        int Delete(int id);
        int Save(Product item);
        Product GetById(int id);
        Task<PagingResult<Usp_GetProductPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
