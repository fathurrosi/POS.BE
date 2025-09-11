using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetByKey(string username);
        List<User> GetAll();
        int Create(User item);
        int Update(User item);
        int Delete(string username);
        int DeleteByFK(int roleID);
        int DeleteAll();

        Task<PagingResult<Usp_GetUserPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
