namespace csharp_in_a_nutshell._04_Advanced
{
    internal class ExtensionMethods
    {
    }

    public class ExtensionMethodsPlayground
    {
        public static void Play()
        {
            Console.WriteLine("Perl".IsCapitalized());

            Console.WriteLine("Seattle".FirstOnSequence());
            List<int> numbers = new List<int>() { 1, 2, 3, 4 };
            Console.WriteLine(numbers.FirstOnSequence());

            //-- can send other arguments as well
            Console.WriteLine("Historic".AddPrefix("Pre"));

            //-- use extension methods as a fluent pattern
            Console.WriteLine("Historic".AddPrefix("Pre").FirstOnSequence());

        }
    }

    public static class StringHelper
    {
        public static bool IsCapitalized(this string s)
        { 
            if(string.IsNullOrEmpty(s))
                return false;
            return char.IsUpper(s[0]);
        }

        public static T FirstOnSequence<T>(this IEnumerable<T> sequence)
        {
            foreach (T element in sequence)
            {
                return element;
            }

            throw new InvalidOperationException("No elements!");
        }

        public static string AddPrefix(this string word, string prefix)
        {
            return $"{prefix}-{word}";
        }
    }

}   
