using Cashback.Domain.Dtos.Orders;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IOrderService
    {
        Task Create(CreateOrderDto orderInfo, string retailerCpf);
    }
}