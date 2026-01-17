namespace csharp_in_a_nutshell._04_Advanced;

public class IteratorsPlayground : IPlayground
{
    public void Play()
    {
        Console.WriteLine("Fibonacci sequence:");
        foreach (int fib in Fibs(10))
        {
            Console.Write($"{fib} ");
        }
        Console.WriteLine();
        Console.WriteLine("Even Fibonacci numbers:");
        foreach (int evenFib in EvenNumbersOnly(Fibs(10)))
        {
            Console.Write($"{evenFib} ");
        }
        Console.WriteLine();
        Console.WriteLine("Foo():");
        foreach (string s in Foo())
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("Foo2(breakEarly: true):");
        foreach (string s in Foo2(true))
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("Foo2(breakEarly: false):");
        foreach (string s in Foo2(false))
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("RareFoo():");
        foreach (string s in RareFoo())
        {
            Console.WriteLine(s);
            if (s == "One")
                break; // to test finally block
        }
    }

    /// <summary>
    /// Returns the Fibonacci sequence given a number
    /// </summary>
    /// <param name="fibCount"></param>
    /// <returns></returns>
    public static IEnumerable<int> Fibs(int fibCount)
    {
        for (int i = 0, prevFib = 1, currFib = 1; i < fibCount; i++)
        {
            yield return prevFib;
            int newFib = prevFib + currFib;
            prevFib = currFib;
            currFib = newFib;
        }
    }

    /// <summary>
    /// Only returns the even numbers
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
    {
        foreach (int x in sequence)
            if ((x % 2) == 0)
                yield return x;
    }

    /// <summary>
    /// Returns example strings
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<string> Foo()
    {
        yield return "One";
        yield return "Two";
        yield return "Three";
    }

    /// <summary>
    /// Returns example strings but if the arg is false will break the iteration
    /// </summary>
    /// <param name="breakEarly"></param>
    /// <returns></returns>
    public static IEnumerable<string> Foo2(bool breakEarly)
    {
        yield return "One";
        yield return "Two";

        if (breakEarly)
            yield break;

        yield return "Three";
    }

    //-- typically yield return cannot be inside a try/catch block
    public static IEnumerable<string> RareFoo()
    {
        try
        {
            yield return "One";
            yield return "Two";
        }
        finally
        {

            //-- the finally block is reached when disposing the enumerator.
            //-- so we're ok by using the foreach loop since it always diposes the enumerato
            //-- if we break unexpectetly
            //-- but if we're working explicitly we can use the using statemnt instead

            //-- cannot yield in finally
            //yield return "Two";
            Console.WriteLine("finally block reached");
        }
    }

}
