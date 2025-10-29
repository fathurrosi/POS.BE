using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models.Result;
using POS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        readonly POSContext _context;
        readonly IPOSContextProcedures _contextProc;

        public RoleRepository(POSContext context, IPOSContextProcedures contextProc)
        {
            _context = context;
            _contextProc = contextProc;

        }

        public int Delete(int id)
        {
            Role? item = this._context.Roles.Find(id);
            if (item != null)
            {
                this._context.Roles.Remove(item);
                return this._context.SaveChanges();
            }
            return -1;
        }


        public List<Role> GetAll()
        {
            return this._context.Roles.AsNoTracking().ToList();
        }

        public Role GetById(int id)
        {
            Role? item = this._context.Roles.Find(id);
            if (item != null)
            {
                this._context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }


        public List<Role> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            List<Role> items = _context.Roles.FromSqlRaw("EXECUTE [dbo].[Usp_GetRoleByUsername] @Username", userParam).ToList();
            return items;
        }

        public async Task<PagingResult<Usp_GetRolePagingResult>> GetDataPaging(int pageIndex, int pageSize, string profile)
        {
            var paramTotalRecord = new SqlParameter("@totalRecord", SqlDbType.Int);
            paramTotalRecord.Direction = ParameterDirection.Output;

            var sqlParameters = new[]
            {
                new SqlParameter("@text", ""),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@profile", profile),
                paramTotalRecord,
            };

            PagingResult<Usp_GetRolePagingResult> result = new PagingResult<Usp_GetRolePagingResult>(pageIndex, pageSize);
            result.Items = await _context.SqlQueryAsync<Usp_GetRolePagingResult>("EXEC [dbo].[Usp_GetRolePaging] @text = @text, @pageIndex = @pageIndex, @pageSize = @pageSize, @profile=@profile, @totalRecord = @totalRecord OUTPUT", sqlParameters, default);
            result.TotalCount = (int)paramTotalRecord.Value;

            return result;
        }

        public async Task<List<Usp_GetRoleByProfileResult>> GetRoles(string profile)
        {
            List<Usp_GetRoleByProfileResult> results = await _contextProc.Usp_GetRoleByProfileAsync(profile);
            return results;
        }

        public int Save(Role item)
        {
            Role existing = GetById(item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Description = item.Description;
                return Update(existing);
            }
            else
            {
                return Create(item);
            }
        }

        private int Create(Role item)
        {

            item.CreatedBy = "system";
            item.CreatedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        private int Update(Role item)
        {
            item.ModifiedBy = "system";
            item.ModifiedDate = DateTime.Now;
            this._context.Entry(item).State = EntityState.Modified;
            return this._context.SaveChanges();
        }
    }
}
