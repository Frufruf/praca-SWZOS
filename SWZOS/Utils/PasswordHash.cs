using SWZOS.Models.Account;
using SWZOS.Models.User;
using System;
using System.Security.Cryptography;

namespace SWZOS.Utils
{
    public class PasswordHash
    {
        private const int SALT_SIZE = 32;
        private const int HASH_SIZE = 32;
        private const int ITERATIONS = 8500;

        public static HashedPasswordModel GetHashedPasswordModel(string password)
        {
            var hashedPassword = new HashedPasswordModel();
            var salt = new byte[SALT_SIZE];
            var provider = RandomNumberGenerator.Create();
            provider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS);
            var hash = pbkdf2.GetBytes(HASH_SIZE);

            hashedPassword.Hash = Convert.ToBase64String(hash);
            hashedPassword.Salt = Convert.ToBase64String(salt);

            return hashedPassword;
        }

        public static bool ValidatePassword(string password, string passwordHash, string passwordSalt)
        {
            var correctHash = Convert.FromBase64String(passwordHash);
            var salt = Convert.FromBase64String(passwordSalt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS);
            var hash = pbkdf2.GetBytes(HASH_SIZE);
            return SlowEquals(correctHash, hash);
        }

        public static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
