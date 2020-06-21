using System;
using System.Security.Claims;

namespace Cashback.Application
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
        }

        public bool Login(string username, string password)
        {
            if (username == null) return false;
            return true;
        }
    }
}
