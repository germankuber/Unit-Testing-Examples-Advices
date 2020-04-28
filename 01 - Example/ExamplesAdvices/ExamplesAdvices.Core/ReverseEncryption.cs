using System.Linq;

namespace ExamplesAdvices.Core
{
    public class ReverseEncryption : IEncryption
    {
        public string Encrypt(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}