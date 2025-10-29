using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Repositories
{
    public class PrevillageRepository : IPrevillageRepository
    {
        readonly POSContext _context;
        readonly IPOSContextProcedures _contextProc;

        public PrevillageRepository(POSContext context, IPOSContextProcedures contextProcedures)
        {
            _context = context;
            _contextProc = contextProcedures;
        }

        public async Task<List<Usp_GetPrevillageByProfileRoleResult>> GetByProfileRole(string profile, int role)
        {
            return await _contextProc.Usp_GetPrevillageByProfileRoleAsync(profile, role);
        }

        public async Task<List<VUserPrevillage>> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            return _context.VUserPrevillages.FromSqlRaw("EXECUTE [Usp_GetUserPrevillageByUsername] @Username", userParam).ToList();
        }

        public async Task<object> Save(List<VRolePrevillage> items)
        {
            int roleId = items.FirstOrDefault() != null ? items.FirstOrDefault().RoleId : 0;
            if (roleId == 0)
            {
                throw new ArgumentException("RoleId cannot be zero.");
            }

            var existingItems = await _contextProc.Usp_GetPrevillageByRoleAsync(roleId);

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                foreach (var item in items)
                {
                    var existingItem = existingItems.Where(t => t.MenuID == item.MenuId).ToList();
                    if (existingItem != null && existingItem.Count > 0)
                    {
                        await _contextProc.Usp_UpdatePrevillageAsync(item.MenuId, item.RoleId, item.AllowCreate, item.AllowRead, item.AllowUpdate, item.AllowDelete, item.AllowPrint);
                    }
                    else
                    {
                        await _contextProc.Usp_InsertPrevillageAsync(item.MenuId, item.RoleId, item.AllowCreate, item.AllowRead, item.AllowUpdate, item.AllowDelete, item.AllowPrint);
                    }
                }

                await transaction.CommitAsync();

                return new { success = true };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log the exception
                throw;
            }
        }

    }
}
