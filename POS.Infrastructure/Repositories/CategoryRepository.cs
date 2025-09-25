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
    public class CategoryRepository : ICategoryRepository
    {
        readonly POSContext _context;

        public CategoryRepository(POSContext context) { _context = context; }

        public int Delete(int id)
        {
            Category? item = this._context.Categories.Find(id);
            if (item != null)
            {
                this._context.Categories.Remove(item);
                return this._context.SaveChanges();
            }
            return -1;
        }


        public Category GetByCode(string code, string profile)
        {
            Category? item = this._context.Categories.FirstOrDefault(p => p.Code == code && p.Profile == profile);
            if (item != null)
            {
                this._context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }

        public List<Category> GetByProfile(string profile)
        {
            return this._context.Categories.Where(t=> t.Profile==profile).AsNoTracking().ToList();
        }

        public List<Category> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            List<Category> items = _context.Categories.FromSqlRaw("EXECUTE [dbo].[Usp_GetCategoryByUsername] @Username", userParam).ToList();
            return items;
        }

        public async Task<PagingResult<Usp_GetCategoryPagingResult>> GetDataPaging(int pageIndex, int pageSize)
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

            PagingResult<Usp_GetCategoryPagingResult> result = new PagingResult<Usp_GetCategoryPagingResult>(pageIndex, pageSize);
            result.Items = await _context.SqlQueryAsync<Usp_GetCategoryPagingResult>("EXEC [dbo].[Usp_GetCategoryPaging] @text = @text, @pageIndex = @pageIndex, @pageSize = @pageSize, @totalRecord = @totalRecord OUTPUT", sqlParameters, default);
            result.TotalCount = (int)paramTotalRecord.Value;

            return result;
        }

        public int Save(Category item)
        {
            Category existing = GetByCode(item.Code, item.Profile);
            if (existing != null)
            {
                return Update(item);
            }
            else
            {
                return Create(item);
            }
        }

        private int Create(Category item)
        {

            item.CreatedBy = "system";
            item.CreatedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        private int Update(Category item)
        {
            item.ModifiedBy = "system";
            item.ModifiedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Modified;
            return this._context.SaveChanges();
        }
    }
}
