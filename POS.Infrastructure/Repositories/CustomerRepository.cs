using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly POSContext _context;

        public CustomerRepository(POSContext context) { _context = context; }

        public int Delete(int id)
        {
            Customer? item = this._context.Customers.Find(id);
            if (item != null)
            {
                this._context.Customers.Remove(item);
                return this._context.SaveChanges();
            }
            return -1;
        }


        public List<Customer> GetAll()
        {
            return this._context.Customers.AsNoTracking().ToList();
        }

        public Customer GetByCode(string code, string profile)
        {
            Customer? item = this._context.Customers.FirstOrDefault(p => p.Code == code && p.Profile == profile);
            if (item != null)
            {
                this._context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }


        public List<Customer> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            List<Customer> items = _context.Customers.FromSqlRaw("EXECUTE [dbo].[Usp_GetCustomerByUsername] @Username", userParam).ToList();
            return items;
        }

        public async Task<PagingResult<Usp_GetCustomerPagingResult>> GetDataPaging(int pageIndex, int pageSize)
        {
            var paramTotalRecord = new SqlParameter("@totalRecord", SqlDbType.Int);
            paramTotalRecord.Direction = ParameterDirection.Output;

            var sqlParameters = new[]
            {
                new SqlParameter("@text", ""),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@pageSize", pageSize),
                paramTotalRecord,
            };

            PagingResult<Usp_GetCustomerPagingResult> result = new PagingResult<Usp_GetCustomerPagingResult>(pageIndex, pageSize);
            result.Items = await _context.SqlQueryAsync<Usp_GetCustomerPagingResult>("EXEC [dbo].[Usp_GetCustomerPaging] @text = @text, @pageIndex = @pageIndex, @pageSize = @pageSize, @totalRecord = @totalRecord OUTPUT", sqlParameters, default);
            result.TotalCount = (int)paramTotalRecord.Value;

            return result;
        }

        public int Save(Customer item)
        {
            Customer existing = GetByCode(item.Code, item.Profile);
            if (existing != null)
            {
                return Update(item);
            }
            else
            {
                return Create(item);
            }
        }

        private int Create(Customer item)
        {

            item.CreatedBy = "system";
            item.CreatedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        private int Update(Customer item)
        {
            item.ModifiedBy = "system";
            item.ModifiedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Modified;
            return this._context.SaveChanges();
        }
    }
}
