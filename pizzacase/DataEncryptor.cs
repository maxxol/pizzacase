using System;
using System.Text;
using System.Security.Cryptography;

namespace pizzacase
{
    public static class DataEncryptor
    {
        public static string EncryptData(string data, string key)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.IV = new byte[16];

            byte[] plainBytes = Encoding.UTF8.GetBytes(data);
            byte[] encryptedBytes = aes.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(encryptedBytes);  // <-- this is a string
        }

    }
}
