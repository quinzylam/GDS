using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GDS.Core.Infrastructure.Utils
{
    public sealed class PasswordProvider : IPasswordProvider
    {
        private const int _iterations = 10000;
        private const int _saltSize = 16;
        private const int _hashSize = 20;

        public string GetSecurePassword(string password)
        {
            byte[] salt;
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(salt = new byte[_saltSize]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations);
            try
            {
                var hash = pbkdf2.GetBytes(_hashSize);

                var hashBytes = new byte[_saltSize + _hashSize];
                Array.Copy(salt, 0, hashBytes, 0, _saltSize);
                Array.Copy(hash, 0, hashBytes, _saltSize, _hashSize);

                var base64Hash = Convert.ToBase64String(hashBytes);
                return base64Hash;
            }
            finally
            {
                crypto.Dispose();
                pbkdf2.Dispose();
            }
        }

        public bool IsValid(string password, string securePassword)
        {
            var hashBytes = Convert.FromBase64String(securePassword);

            var salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations);
            try
            {
                byte[] hash = pbkdf2.GetBytes(_hashSize);

                return hash.SequenceEqual(hashBytes.Skip(_saltSize));
            }
            finally
            {
                pbkdf2.Dispose();
            }
        }
    }
}