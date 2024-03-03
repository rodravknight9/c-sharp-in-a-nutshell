using System.Numerics;
using System.Security.Cryptography;

namespace csharp_in_a_nutshell._06_Framework_Fundamentals
{
    internal class WorkingWithNumbers
    {
    }

    public class WorkingWithNumbersPlayground 
    {
        public static void Play()
        {
            BigInteger twentyFive = 25;
            Console.WriteLine(twentyFive);

            BigInteger googol = BigInteger.Parse("1".PadRight(100, '0'));
            Console.WriteLine(googol.ToString());

            double g2 = (double)googol; // Explicit cast
            BigInteger g3 = (BigInteger)g2; // Explicit cast
            Console.WriteLine(g3); // <- lossing precision

            // This uses the System.Security.Cryptography namespace:
            RandomNumberGenerator rand = RandomNumberGenerator.Create();
            byte[] bytes = new byte[32];
            rand.GetBytes(bytes);
            var bigRandomNumber = new BigInteger(bytes);
            Console.WriteLine(bigRandomNumber);

            // complex numbers
            var c1 = new Complex(2, 3.5);
            var c2 = new Complex(3, 0);

            Console.WriteLine(c1.Real); // 2
            Console.WriteLine(c1.Imaginary); // 3.5
            Console.WriteLine(c1.Phase); // 1.05165021254837
            Console.WriteLine(c1.Magnitude); // 4.03112887414927

            Complex c3 = Complex.FromPolarCoordinates(1.3, 5);
            Console.WriteLine(c3);

        }
    }
}
