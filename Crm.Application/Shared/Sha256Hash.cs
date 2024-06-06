using System.Security.Cryptography;
using System.Text;
namespace Crm.Application.Shared
{
    public class Sha256Hash
    {
        private static string salt => "salt&password&8*";
        public static string Hash(string inputValue)
        {
            using var sha256 = SHA256.Create();
            var originalBytes = Encoding.Default.GetBytes(inputValue + salt);
            var encodedBytes = sha256.ComputeHash(originalBytes);
            return Convert.ToBase64String(encodedBytes);
        }
        public static bool IsCompare(string hashText, string rawText)
        {
            var hash = Hash(rawText);
            return hashText == hash;
        }
    }
}
