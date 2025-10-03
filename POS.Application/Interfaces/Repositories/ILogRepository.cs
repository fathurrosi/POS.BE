using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Application.Interfaces.Repositories
{
    public interface ILogRepository
    {
        int Create(Log item);

        Task<PagingResult<Usp_GetLogPagingResult>> GetDataPaging(int pageIndex, int pageSize);
    }
}
