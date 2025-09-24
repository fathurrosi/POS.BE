using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetByUsername(string username);
        
        List<Customer> GetAll(); 
        int Delete(int id);
        int Save(Customer item);
        Customer GetById(int id);
        Task<PagingResult<Usp_GetCustomerPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
