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
    public class SupplierRepository : ISupplierRepository
    {
        readonly POSContext _context;

        public SupplierRepository(POSContext context) { _context = context; }

        public int Delete(int id)
        {
            Supplier? item = this._context.Suppliers.Find(id);
            if (item != null)
            {
                this._context.Suppliers.Remove(item);
                return this._context.SaveChanges();
            }
            return -1;
        }


        public List<Supplier> GetAll()
        {
            return this._context.Suppliers.AsNoTracking().ToList();
        }

        public Supplier GetByCode(string code, string profile)
        {
            Supplier? item = this._context.Suppliers.Find(code);
            if (item != null)
            {
                this._context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }


        public List<Supplier> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            List<Supplier> items = _context.Suppliers.FromSqlRaw("EXECUTE [dbo].[Usp_GetSupplierByUsername] @Username", userParam).ToList();
            return items;
        }

        public async Task<PagingResult<Usp_GetSupplierPagingResult>> GetDataPaging(int pageIndex, int pageSize)
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

            PagingResult<Usp_GetSupplierPagingResult> result = new PagingResult<Usp_GetSupplierPagingResult>(pageIndex, pageSize);
            result.Items = await _context.SqlQueryAsync<Usp_GetSupplierPagingResult>("EXEC [dbo].[Usp_GetSupplierPaging] @text = @text, @pageIndex = @pageIndex, @pageSize = @pageSize, @totalRecord = @totalRecord OUTPUT", sqlParameters, default);
            result.TotalCount = (int)paramTotalRecord.Value;

            return result;
        }

        public int Save(Supplier item)
        {
            Supplier existing = GetByCode(item.Code, item.Profile);
            if (existing != null)
            {
                return Update(item);
            }
            else
            {
                return Create(item);
            }
        }

        private int Create(Supplier item)
        {

            item.CreatedBy = "system";
            item.CreatedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        private int Update(Supplier item)
        {
            item.ModifiedBy = "system";
            item.ModifiedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Modified;
            return this._context.SaveChanges();
        }
    }
}
