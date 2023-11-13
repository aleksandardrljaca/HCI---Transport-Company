using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADTransport.Data.HashUtils
{
    public class HashUtil
    {

        public static readonly string HashAlgorithm = "SHA-512";

        public static string GetHash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha512.ComputeHash(inputBytes);
                return BytesToHex(hashBytes);
            }
        }

        public static string BytesToHex(byte[] hash)
        {
            StringBuilder hexString = new StringBuilder(2 * hash.Length);
            foreach (byte b in hash)
            {
                hexString.AppendFormat("{0:x2}", b);
            }
            return hexString.ToString();
        }
    }
}
