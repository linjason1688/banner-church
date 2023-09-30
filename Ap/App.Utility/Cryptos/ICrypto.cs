namespace App.Utility.Cryptos
{
    public interface ICrypto
    {
        string Encrypt(string text, string salt = "");

        string Decrypt(string text);
    }
}
