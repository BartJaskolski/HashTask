using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            //259 + 277  9,583 10,249   354,571 379,213
            //13625924
//            Console.WriteLine(GetHash("rano"));
            List<long> lista = new List<long>
            {
                GetHash("nowy"),
                GetHash("prosto"),
                GetHash("liczne"),
                (long)379214
            };
            foreach (var hash in lista)
            {
                Console.WriteLine(DecodeHash(hash));
            }
            //Console.WriteLine(DecodeHash(13625924));

            //Console.WriteLine();

            //Console.WriteLine();
            ////25157672851591
            //Console.WriteLine(DecodeHash(25157672851591));
            Console.ReadKey();
        }

        private static string DecodeHash(long hashValue)
        {
            const string AVAILABLE_CHARS_FOR_HASH = "acegilmnoprstuwxyz";
            const long MINIMAL_VALUE_FOR_HASH = 259;

            string result = String.Empty;

            if (hashValue < MINIMAL_VALUE_FOR_HASH)
                throw new Exception("Hash value is invalid, valid value start from 259");
            do
            {
                long currentModulo = hashValue % 37;
                hashValue /= 37;

                if (currentModulo>=AVAILABLE_CHARS_FOR_HASH.Length || hashValue < 7)
                    throw new Exception("Hash value is invalid, valid values for modulo <0,17>");

                result = AVAILABLE_CHARS_FOR_HASH[(int)currentModulo] + result;
                
            } while (hashValue != 7);

            return result; 
        }

        static long GetHash(string s)
        {
            long h = 7;
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(h +" * 37 + "+ "acegilmnoprstuwxyz".IndexOf(s[i]));
                h = h * 37 + "acegilmnoprstuwxyz".IndexOf(s[i]);

            }
            return h;
        }
    }
}
