using Cashback.Domain.Dtos.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IOrderService
    {
        Task Create(CreateOrderDto orderInfo, string retailerCpf);
        Task<IEnumerable<OrderDetailsDto>> ListCurrentMonth(string retailerCpf);
    }
}