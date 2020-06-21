namespace Cashback.WebApi.Util
{
    public interface IJwtTokenService
    {
        string CreateJwtToken(string name);
    }
}
