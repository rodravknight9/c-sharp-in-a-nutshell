using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._06_Framework_Fundamentals
{
    internal class EqualityComparision
    {
    }

    public class EqualityComparisionPlayground
    {

        public static void Play()
        {
            // There are two kinds of equality:
            // Value equality: Two values are equivalent in some sense.
            // Referential equality: Two references refer to exactly the same object.

            // By default:
            // Value types use value equality.
            // Reference types use referential equality.

            // Value equality:
            int x = 5, y = 5;
            Console.WriteLine(x == y);

            // Referential equality:
            var dt1 = new DateTimeOffset(2010, 1, 1, 1, 1, 1, TimeSpan.FromHours(8));
            var dt2 = new DateTimeOffset(2010, 1, 1, 2, 1, 1, TimeSpan.FromHours(9));
            Console.WriteLine(dt1 == dt2); // True

            Foo f1 = new Foo { X = 5 };
            Foo f2 = new Foo { X = 5 };
            Console.WriteLine(f1 == f2);

            Foo f3 = f1;
            Console.WriteLine(f1 == f3);

            // this is a special cas, they;re using a customized value equality
            Uri uri1 = new Uri("http://www.linqpad.net");
            Uri uri2 = new Uri("http://www.linqpad.net");
            Console.WriteLine(uri1 == uri2);
        }

    }

    class Foo { public int X; }


}
