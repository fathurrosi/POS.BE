using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        List<Supplier> GetByUsername(string username);
        
        List<Supplier> GetAll(); 
        int Delete(int id);
        int Save(Supplier item);
        Supplier GetById(int id);
        Task<PagingResult<Usp_GetSupplierPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
