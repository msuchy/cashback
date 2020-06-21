using System;

namespace Cashback.Application
{
    public interface IAuthService
    {
        bool Login(string username, string password);
    }
}