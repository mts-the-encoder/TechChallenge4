using Application.Services.Cryptography;

namespace Utils.Tests.Cryptography;

public class PasswordEncryptorBuilder
{
    public static PasswordEncryptor Instance()
    {
        return new PasswordEncryptor("FIAP14000");
    }
}