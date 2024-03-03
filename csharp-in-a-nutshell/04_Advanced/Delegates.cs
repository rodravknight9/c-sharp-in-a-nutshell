namespace csharp_in_a_nutshell._04_Advanced
{
    /// <summary>
    /// Delegates section, chapter 04
    /// </summary>
    internal class Delegates
    {
        /*
            This class should cover delegates topics as
            
            - Generic Delegates.
            - Multicase Delegates.
            - Delegates vs Interfaces.
            - Func<>().
            - Events.
        */
    }

    /// <summary>
    /// Class that contains simple methods to be used when using delegates
    /// </summary>
    public class CallableMethods
    {
        /// <summary>
        /// Makes the square of a number.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MakeSquare(int x) => x * x;

        /// <summary>
        /// Makes the sum of two numbers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MakeSum(int x, int y) => x + y;

        /// <summary>
        /// Makes the product of two numbers.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MakeProduct(int x, int y) => x * y;

        public int DummyTest(int x, string y) => x;


        /// <summary>
        /// It shows a message with a salute in Latin
        /// </summary>
        /// <param name="name"></param>
        public void SaluteInLatin(string name)
        {
            Console.WriteLine($"Salve {name}");
        }

        /// <summary>
        /// It displays a salute message in Italian
        /// </summary>
        /// <param name="name"></param>
        public void SaluteInItalian(string name)
        {
            Console.WriteLine($"Ciao {name}");
        }

    }

    #region Delgates

    /// <summary>
    /// Simple delegate that handle mathematical calculations with only one number
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public delegate int MathCalculationOneNumber(int x);


    /// <summary>
    /// Simple delegate that handle mathematical calculations with two numbers
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public delegate int MathCalculationTwoNumbers(int x, int y);


    /// <summary>
    /// Simple delegate that handles simple slautes in different languages
    /// </summary>
    /// <param name="name"></param>
    public delegate void SaluteHandler(string name);


    /// <summary>
    /// Delegate that handles the prices changes.
    /// </summary>
    /// <param name="oldPrice"></param>
    /// <param name="newPrice"></param>
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    #endregion


}
