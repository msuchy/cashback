using Cashback.Domain.Orders;
using System.Threading.Tasks;

namespace Cashback.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);
    }
}