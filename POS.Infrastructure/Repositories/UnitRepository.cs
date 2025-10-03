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
    public class UnitRepository : IUnitRepository
    {
        readonly POSContext _context;

        public UnitRepository(POSContext context) { _context = context; }


        public int Delete(string code, string profile)
        {
            Unit? item = this._context.Units.FirstOrDefault(p => p.Code == code && p.Profile == profile);
            if (item != null)
            {
                this._context.Units.Remove(item);
                return this._context.SaveChanges();
            }
            return -1;
        }

        public Unit GetByCode(string code, string profile)
        {
            Unit? item = this._context.Units.FirstOrDefault(p => p.Code == code && p.Profile == profile);
            if (item != null)
            {
                this._context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }

        public List<Unit> GetByProfile(string profile)
        {
            return this._context.Units.Where(t=> t.Profile==profile).AsNoTracking().ToList();
        }

        public List<Unit> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            List<Unit> items = _context.Units.FromSqlRaw("EXECUTE [dbo].[Usp_GetUnitByUsername] @Username", userParam).ToList();
            return items;
        }

        public async Task<PagingResult<Usp_GetUnitPagingResult>> GetDataPaging(int pageIndex, int pageSize, string profile)
        {
            var paramTotalRecord = new SqlParameter("@totalRecord", SqlDbType.Int);
            paramTotalRecord.Direction = ParameterDirection.Output;

            var sqlParameters = new[]
            {
                new SqlParameter("@text", ""),
                new SqlParameter("@profile", profile),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@pageSize", pageSize),
                paramTotalRecord,
            };

            PagingResult<Usp_GetUnitPagingResult> result = new PagingResult<Usp_GetUnitPagingResult>(pageIndex, pageSize);
            result.Items = await _context.SqlQueryAsync<Usp_GetUnitPagingResult>("EXEC [dbo].[Usp_GetUnitPaging] @search = @text,@profile =@profile, @pageIndex = @pageIndex, @pageSize = @pageSize, @totalRecord = @totalRecord OUTPUT", sqlParameters, default);
            result.TotalCount = (int)paramTotalRecord.Value;

            return result;
        }

        public int Save(Unit item)
        {
            Unit existing = GetByCode(item.Code, item.Profile);
            if (existing != null)
            {
                return Update(item);
            }
            else
            {
                return Create(item);
            }
        }

        private int Create(Unit item)
        {

            item.CreatedBy = "system";
            item.CreatedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        private int Update(Unit item)
        {
            item.ModifiedBy = "system";
            item.ModifiedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Modified;
            return this._context.SaveChanges();
        }
    }
}
