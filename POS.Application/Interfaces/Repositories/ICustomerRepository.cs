using POS.Domain.Entities;
using POS.Domain.Models.Result;
namespace POS.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetByUsername(string username);
        List<Customer> GetByProfile(string profile);
        //List<Customer> GetAll(); 
        int Delete(int id);
        int Save(Customer item);
        Customer GetByCode(string code, string profile);
        Task<PagingResult<Usp_GetCustomerPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
