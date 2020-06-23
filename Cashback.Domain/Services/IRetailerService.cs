using Cashback.Domain.Dtos.Retailers;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IRetailerService
    {
        Task Create(CreateRetailerDto retailerInfo);
    }
}