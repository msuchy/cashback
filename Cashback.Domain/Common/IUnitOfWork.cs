using System.Threading.Tasks;

namespace Cashback.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges(int? timeout = null);
    }
}
