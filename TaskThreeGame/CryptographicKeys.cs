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

        public static int MakeComputerMove(int upperBound)
        {
            return RandomNumberGenerator.GetInt32(upperBound);
        }
    }
}