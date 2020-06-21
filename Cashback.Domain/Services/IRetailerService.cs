using System;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IRetailerService
    {
        Task Create(string cpf, string name, string email, string password);
    }
}