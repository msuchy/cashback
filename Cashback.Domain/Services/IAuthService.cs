using System;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
    }
}