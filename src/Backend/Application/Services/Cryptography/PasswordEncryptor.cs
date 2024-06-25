using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Cryptography;

public class PasswordEncryptor
{
    private readonly string _additionalKey = "mTSzx3@P$LS!";

    public PasswordEncryptor(string additionalKey)
    {
        _additionalKey = additionalKey;
    }

    public string Encrypt(string password)
    {
        var passwordWithKey = $"{password}{_additionalKey}";

        var bytes = Encoding.UTF8.GetBytes(passwordWithKey);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);
        return StringBytes(hashBytes);
    }


    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}