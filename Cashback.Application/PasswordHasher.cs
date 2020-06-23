using Cashback.Domain.Common;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Cashback.Application
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; 
        private const int KeySize = 32; 
        private const int Iterations = 1000; 


        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              SaltSize,
              Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{Iterations}.{salt}.{key}";
            }
        }

        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.');

            if (parts.Length != 3)
            {
                throw new ArgumentException("Unexpected hash format. " +
                  "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              iterations))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }
    }
}
