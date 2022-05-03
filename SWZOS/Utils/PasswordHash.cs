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

        public void CreateHashForUser(UserFormModel user)
        {
            var salt = new byte[SALT_SIZE];
            var provider = RandomNumberGenerator.Create();
            provider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, ITERATIONS);
            var hash = pbkdf2.GetBytes(HASH_SIZE);

            user.Hash = Convert.ToBase64String(hash);
            user.Salt = Convert.ToBase64String(salt);
        }

        public bool ValidatePassword(string password, string passwordHash, string passwordSalt)
        {
            var oldHash = Convert.FromBase64String(passwordHash);
            var salt = Convert.FromBase64String(passwordSalt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS);
            var hash = pbkdf2.GetBytes(HASH_SIZE);
            return SlowEquals(oldHash, hash);
        }

        public bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
