using DemoCoreAPI.BusinessLogic.Commands;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Utilities
{
    public static class Utilities
    {
        public static string HashPassword(string password)
        {
            return UseHash256(Encoding.UTF8.GetBytes(password));
        }

        public static bool ComparePasswords(RegisterCommand model)
        {
            if (model.Password == model.PasswordConfirmation)
                return true;
            else
                return false;
        }

        private static string UseHash256(byte[] input)
        {
            using (var algo = HashAlgorithm.Create("sha256"))
            {
                return Convert.ToBase64String(algo.ComputeHash(input));
            }
        }
    }
}
