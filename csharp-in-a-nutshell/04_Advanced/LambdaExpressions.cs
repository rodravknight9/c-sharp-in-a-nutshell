namespace csharp_in_a_nutshell._04_Advanced;

public class LambdaExpressionsPlayground : IPlayground
{
    public void Play()
    {
        //-- Example of generic method with Action<T>
        LambdaExamples le = new LambdaExamples();
        le.Foo<int>(5);
        le.Bar<string>(s => Console.WriteLine(s.ToUpper()));
        //-- Example of closure
        Func<int> nat = LambdaExamples.Natural();
        Console.WriteLine(nat()); //0
        Console.WriteLine(nat()); //1
        Console.WriteLine(nat()); //2
        Func<int> nonNat = LambdaExamples.NonDesiredNatural();
        Console.WriteLine(nonNat()); //0
        Console.WriteLine(nonNat()); //0
        Console.WriteLine(nonNat()); //0
    }
}

internal class LambdaExpressions
{
    //-- 1. Review what is a closure.

}

public class LambdaExamples
{
    delegate int Transformer(int i);

    public void Foo<T>(T x)
    {
        Console.WriteLine(x);
    }

    public void Bar<T>(Action<T> a)
    {
       
    }

    /// <summary>
    /// The current func will act as the seed variable has been captured, 
    /// therefore the lifetime of seed will long until the invocation of the delegate
    /// </summary>
    /// <returns></returns>
    public static Func<int> Natural()
    {
        int seed = 0;
        return () => seed++; //returns a closure
    }

    /// <summary>
    /// In this case the same action, but the seed variable will have a scoped lifetime
    /// </summary>
    /// <returns></returns>
    public static Func<int> NonDesiredNatural()
    {
        return () =>
        {
            int seed = 0;
            return seed++;
        };
    }

}
