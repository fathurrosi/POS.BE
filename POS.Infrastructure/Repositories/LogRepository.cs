using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        readonly POSContext _context;

        public LogRepository(POSContext context) { _context = context; }
        public int Create(Log item)
        {
            this._context.Entry(item).State = EntityState.Added;
            return this._context.SaveChanges();
        }

        public Task<PagingResult<Usp_GetLogPagingResult>> GetDataPaging(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
