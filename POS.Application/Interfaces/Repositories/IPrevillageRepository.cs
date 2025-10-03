using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IPrevillageRepository
    {
        public List<VUserPrevillage> GetByUsername(string username);
    }
}
