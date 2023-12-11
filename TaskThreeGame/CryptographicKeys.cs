using System.Security.Cryptography;
using System.Text;

namespace TaskThreeGame
{
    public class CryptographicKeys
    {
        private readonly GameMoves moves;
        public string Key { get; }
        public int ComputerMove { get; }
        public string Hmac { get; }

        public CryptographicKeys(GameMoves moves)
        {
            this.moves = moves;
            Key = GetRandomKey();
            ComputerMove = MakeComputerMove();
            Hmac = GetHmac(moves.Moves[ComputerMove], Key);
        }

        public static string GetRandomKey() =>
            Convert.ToHexString(RandomNumberGenerator.GetBytes(32));

        private int MakeComputerMove() =>
            RandomNumberGenerator.GetInt32(moves.Moves.Length);

        public static string GetHmac(string message, string secret)
        {
            UTF8Encoding encoding = new();
            HMACSHA256 cryptographer = new(encoding.GetBytes(secret));
            byte[] bytes = cryptographer.
                ComputeHash(encoding.GetBytes(message));
            return Convert.ToHexString(bytes);
        }
    }
}