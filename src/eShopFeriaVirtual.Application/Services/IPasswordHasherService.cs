using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Services
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password, out byte[] salt);
        bool VerifyPassword(string password, string hash, byte[] salt);
    }

    public class PasswordHasherService : IPasswordHasherService
    {
        const int KEY_SIZE = 64;
        const int ITERATIONS = 4000;
        HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
        public string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(KEY_SIZE);
            byte[] hashByte = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password), salt, ITERATIONS, HashAlgorithm, KEY_SIZE);
            return Convert.ToBase64String(hashByte);
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashGenerated = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, HashAlgorithm, KEY_SIZE);
            return hashGenerated.SequenceEqual(Convert.FromBase64String(hash));
        }
    }
}
