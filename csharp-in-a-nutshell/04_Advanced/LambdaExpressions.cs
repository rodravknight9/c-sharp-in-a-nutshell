using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._04_Advanced
{
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
        /// The actual func will acting as the seed variable has been captured, 
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


}
