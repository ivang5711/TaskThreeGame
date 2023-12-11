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

        public static string GetHmac(string text, string hexKey)
        {
            UTF8Encoding encoding = new();
            HMACSHA256 hmac = new(encoding.GetBytes(hexKey));
            return Convert.ToHexString(
                hmac.ComputeHash(encoding.GetBytes(text)));
        }
    }
}