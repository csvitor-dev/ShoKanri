using System.Security.Cryptography;
using System.Text;

namespace ShoKanri.Application.Services;

public class PasswordEncryptionService(string key)
{
    private readonly string _key = key;

    public string Encrypt(string password)
    {
        password = $"{password}{_key}";
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.HashData(bytes);

        return BuildString(hash);
    }
    private string BuildString(byte[] bytes)
    {
        StringBuilder sb = new();

        foreach (byte b in bytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}