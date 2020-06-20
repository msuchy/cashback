using System;

namespace Cashback.WebApi.Models.Auth
{
    public class LoginApiModel{
        public string CPF { get; set; }
        public string Password { get; set; }
    }
}