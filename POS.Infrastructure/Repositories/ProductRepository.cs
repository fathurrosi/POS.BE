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
    public class ProductRepository : IProductRepository
    {
        readonly POSContext _context;

        public ProductRepository(POSContext context) { _context = context; }

        public int Delete(int id)
        {
            Product? item = this._context.Products.Find(id);
            if (item != null)
            {
                this._context.Products.Remove(item);
                return this._context.SaveChanges();
            }
            return -1;
        }

        public List<Product> GetByProfile(string profile)
        {
            return this._context.Products.Where(t => t.Profile == profile).AsNoTracking().ToList();
        }

        public Product GetByCode(string code, string profile)
        {
            Product? item = this._context.Products.FirstOrDefault(p => p.UniqueCode == code && p.Profile == profile);

            if (item != null)
            {
                this._context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }


        public List<Product> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            List<Product> items = _context.Products.FromSqlRaw("EXECUTE [dbo].[Usp_GetProductByUsername] @Username", userParam).ToList();
            return items;
        }

        public async Task<PagingResult<Usp_GetProductPagingResult>> GetDataPaging(int pageIndex, int pageSize)
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

            PagingResult<Usp_GetProductPagingResult> result = new PagingResult<Usp_GetProductPagingResult>(pageIndex, pageSize);
            result.Items = await _context.SqlQueryAsync<Usp_GetProductPagingResult>("EXEC [dbo].[Usp_GetProductPaging] @text = @text, @pageIndex = @pageIndex, @pageSize = @pageSize, @totalRecord = @totalRecord OUTPUT", sqlParameters, default);
            result.TotalCount = (int)paramTotalRecord.Value;

            return result;
        }

        public int Save(Product item)
        {
            Product existing = GetByCode(item.UniqueCode, item.Profile);
            if (existing != null)
            {
                return Update(item);
            }
            else
            {
                return Create(item);
            }
        }

        private int Create(Product item)
        {

            item.CreatedBy = "system";
            item.CreatedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        private int Update(Product item)
        {
            item.ModifiedBy = "system";
            item.ModifiedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Modified;
            return this._context.SaveChanges();
        }
    }
}
