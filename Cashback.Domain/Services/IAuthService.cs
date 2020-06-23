using Cashback.Domain.Dtos.Auth;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto loginInfo);
    }
}