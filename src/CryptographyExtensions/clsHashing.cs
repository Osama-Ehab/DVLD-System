using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyExtensions
{
    public static class clsHashing
    {
        public static string ComputeHash(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes);//.Replace("-", "").ToLower();
            }
        }
        public static string Hashing(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
        public static bool Verification(string input,string hashedText)
        {
           return input.Hashing() == hashedText;
        }
        public static bool IsValid(this string hashedText, string input)
        {
            return hashedText == input.Hashing();
        }
    }
}
