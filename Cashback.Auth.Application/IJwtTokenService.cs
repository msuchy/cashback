namespace Cashback.Auth.Application
{
    public interface IJwtTokenService
    {
        string CreateJwtToken(string name);
    }
}
