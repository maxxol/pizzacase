using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace pizzacase
{
    internal class DataDecryptor
    {

        public static string DecryptData(string data, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(data);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.IV = new byte[16];

            byte[] decryptedBytes = aes.CreateDecryptor().TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
