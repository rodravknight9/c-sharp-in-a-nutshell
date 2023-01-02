using csharp_in_a_nutshell._04_Advanced;

foreach (var item in Iterators.Fibs(6))
{
    Console.WriteLine(item);
}

foreach (var item in Iterators.Foo())
{
    Console.WriteLine(item);
}

foreach (var item in Iterators.Foo2(true))
{
    Console.WriteLine(item);
}

foreach (var item in Iterators.RareFoo())
{
    Console.WriteLine(item);
}

//-- using the safe way by iterating a enumerator within a try/finally block
string firstElement = null;
var sequence = Iterators.RareFoo();
using (var enumerator = sequence.GetEnumerator())
{
    if (enumerator.MoveNext())
        firstElement = enumerator.Current;
}
Console.WriteLine(firstElement);


foreach (var item in Iterators.EvenNumbersOnly(Iterators.Fibs(6)))
{
    Console.WriteLine(item);
}
