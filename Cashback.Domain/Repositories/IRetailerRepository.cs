using System.Threading.Tasks;
using Cashback.Domain.Common;
using Cashback.Domain.Retailers;

namespace Cashback.Domain.Repositories{
    public interface IRetailerRepository
    {
        Task Add(Retailer retailer);
        Task<Retailer> Find(Cpf cpf);
    }
}