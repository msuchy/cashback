using Cashback.Domain.Dtos.Auth;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IAuthService
    {
        Task<bool> Login(LoginDto loginInfo);
    }
}