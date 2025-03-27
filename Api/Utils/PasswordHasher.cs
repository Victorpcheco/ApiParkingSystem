using System.Security.Cryptography;
using System.Text;

namespace Api.Utils;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    public static bool VerifyHashedPassword(string password, string hashedPassword)
    {
        return HashPassword(password) == hashedPassword;
    }
}