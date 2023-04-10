namespace csharp_in_a_nutshell._04_Advanced
{
    internal class Tuples
    {
    }

    public class TuplesPlayground
    {
        public static void Play()
        {
            //-- we can access to the tuple values through the ItemX property
            var bob = ("Bob", 23);
            Console.WriteLine(bob.Item1);
            Console.WriteLine(bob.Item2);

            //-- tuples are value types
            var joe = bob;
            joe.Item1 = "Joe";
            Console.WriteLine(bob);
            Console.WriteLine(joe);

            //-- we can also specify its type
            (string, int) bob2 = ("Bob", 24);

            //-- also we can return tuples by using methods
            var bob3 = GetPerson();
            Console.WriteLine(bob3);

            //-- also works fine with generics
            var genericExample =
                new Dictionary<int, (string, string, int)>();
            genericExample.Add(1, ("Lennon", "John", 1940));
            genericExample.Add(2, ("McCartney", "Paul", 1942));
            Console.WriteLine(genericExample[1].Item1);
            Console.WriteLine(genericExample[2].Item1);

            //-- we can also give variable names to a tuple
            var bob4 = (Name: "Bob", Age: 23);
            Console.WriteLine(bob4.Name);

            //-- no errors since they have the same shape 
            var james1 = (Name: "James", Age: 45);
            bob4 = james1;
            Console.WriteLine(bob4.Name);

            //-- also we can create tuples as follow
            ValueTuple<string, string> song1 = ValueTuple.Create("Everythin' Now", "Arcade Fire");
            Console.WriteLine(song1.Item1);

            //-- deconstructing the tuple:
            (string name, string rockband) = song1;
            Console.WriteLine($"{name} - {rockband}");

            //-- types override the Equals method to allow equality comparisons
            var t1 = ("one", 1);
            var t2 = ("one", 1);
            Console.WriteLine(t1.Equals(t2)); // True
        }

        /// <summary>
        /// Simply return the ("Bob", 23) tuple
        /// </summary>
        /// <returns></returns>
        static (string, int) GetPerson() => ("Bob", 23);
    }


}
