using csharp_in_a_nutshell._19_Reflection_and_Metadata;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._06_Framework_Fundamentals
{
    public class StringAndTextHandling
    {
    }

    public class StringAndTextHandlingPlayground
    {
        public static void Play()
        {
            // chosse the culture when displaying text
            Console.WriteLine(char.ToUpperInvariant('i'));
            Console.WriteLine(char.ToUpper('i', CultureInfo.InvariantCulture));

            // strings
            string s1 = "Hello";
            string s2 = "First Line\r\nSecond Line";
            string s3 = @"
            The path is:
            \\server\fileshare\helloworld.cs"; //@ allows to have \ and even new line
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            // parse string into char and viceversa
            char[] ca = "Hello".ToCharArray();
            string s = new string(ca);
            Console.WriteLine(s);

            foreach (char c in "123") Console.Write(c + ",");

            Console.WriteLine();

            Console.WriteLine("quick brown fox".EndsWith("fox")); // True
            Console.WriteLine("quick brown fox".Contains("brown")); // True

            Console.WriteLine("abcdef".StartsWith("aBc", StringComparison.InvariantCultureIgnoreCase));

            // using indeof using an entry point
            Console.WriteLine("abcde abcde".IndexOf("CD", 6,
                StringComparison.CurrentCultureIgnoreCase)); // 8

            Console.Write("pas5w0rd".IndexOfAny("0123456789".ToCharArray()));

            // substrings very known methods...
            string left3 = "12345".Substring(0, 3); // left3 = "123";
            string mid3 = "12345".Substring(1, 3); // mid3 = "234";
            string ns1 = "helloworld".Insert(5, ", "); // s1 = "hello, world"
            string ns2 = ns1.Remove(5, 2);


            // eyes on this: PadLeft and PadRight!
            // they use char instead of string
            Console.WriteLine("12345".PadLeft(9, '*')); // ****12345
            Console.WriteLine("12345".PadLeft(9));

            Console.WriteLine("Hello".PadRight(8, '!')); // will add !!! at the end

            // Trims
            Console.WriteLine(" abc \t\r\n ".Trim());
            Console.WriteLine(" abc \t\r\n ".TrimStart());
            Console.WriteLine(" abc \t\r\n ".TrimEnd());

            // spliting and joining
            string[] words = "The quick brown fox".Split();
            string together = string.Join(" ", words);

            // Eyes on this: O.o
            string composite = "It's {0} degrees in {1} on this {2} morning";
            string form = string.Format(composite, 35, "Perth", DateTime.Now.DayOfWeek);
            Console.WriteLine(form);

            // 0 and 1 means the args positions
            // -20 means left-aligned
            // 15:C C is for curreny
            string composite2 = "Name={0,-20} Credit Limit={1,15:C}";
            Console.WriteLine(string.Format(composite2, "Mary", 500));
            Console.WriteLine(string.Format(composite2, "Elizabeth", 20000));

            Console.WriteLine(string.Equals("ṻ", "ǖ", StringComparison.CurrentCulture));

            //Text Encodings and Unicode
            // Unicode covers most spoken world languages, as well as some historical languages and special symbols.
            // The ASCII set is simply thefirst 128 characters of the Unicode set

            Encoding utf8 = Encoding.GetEncoding("utf-8");
            //Encoding chinese = Encoding.GetEncoding("GB18030");

            // supported encodings
            foreach (EncodingInfo info in Encoding.GetEncodings())
                Console.WriteLine(info.Name);            System.IO.File.WriteAllText("data.txt", "testing", Encoding.Unicode);
        }
    }
}
