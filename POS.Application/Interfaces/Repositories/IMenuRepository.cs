using Microsoft.Data.SqlClient;
using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        List<Menu> GetAll();
        List<Menu> GetByUsername(string username);
        Menu GetById(int id);
        public Task<PagingResult<Usp_GetMenuPagingResult>> GetDataPaging(int pageIndex, int pageSize);
        //int Create(Menu item);
        //int Update(Menu item);

        int Save(Menu item);
        int Delete(int id);

    }
}
