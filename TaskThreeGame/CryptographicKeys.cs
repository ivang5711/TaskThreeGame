using System.Security.Cryptography;

namespace TaskThreeGame
{
    public class CryptographicKeys
    {
        public byte[] Key { get; }

        public CryptographicKeys()
        {
            Key = GetRandomKey();
        }

        public static byte[] GetRandomKey()
        {
            return RandomNumberGenerator.GetBytes(32);
        }
    }
}