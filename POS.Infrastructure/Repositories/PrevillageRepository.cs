using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var profileParam = new SqlParameter("@profile", profile);
            //var roleParam = new SqlParameter("@role", role);
            //return _context.VUserPrevillages.FromSqlRaw("EXECUTE [Usp_GetPrevillageByProfileRole] @profile=@profile, @role=@role", profileParam, roleParam).ToList();

            return await _contextProc.Usp_GetPrevillageByProfileRoleAsync(profile, role);
        }

        public async Task<List<VUserPrevillage>> GetByUsername(string username)
        {
            var userParam = new SqlParameter("@Username", username);
            return _context.VUserPrevillages.FromSqlRaw("EXECUTE [Usp_GetUserPrevillageByUsername] @Username", userParam).ToList();
            //List<VUserPrevillage> items = _context.VUserPrevillages.FromSqlRaw("EXECUTE [Usp_GetUserPrevillageByUsername] @Username", userParam).ToList();
            //return items;

            //return await _contextProc.Usp_GetPrevillageByUsernameAsync(username);
        }
    }
}
