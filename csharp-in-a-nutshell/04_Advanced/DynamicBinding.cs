using System.Dynamic;

namespace csharp_in_a_nutshell._04_Advanced
{
    public class DynamicBinding
    {
    }

    public class DynamicBindingPlayground 
    {

        /// <summary>
        /// Language Binding
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static dynamic Mean(dynamic x, dynamic y) => (x + y) / 2;

        public static void Play()
        {
            //-- using dynamic we tell the compiler to relax,
            //-- won't check if the Quack() method exists
            dynamic simDuck = new SimpleDuck();
            //simDuck.Quack(); // <-- will give an error

            dynamic dynDuck = new DynamicDuck();
            dynDuck.Quack();
            dynDuck.Walk();

            //-- when using Language Binding no need to worry about numeric types
            Console.WriteLine(Mean(3, 5));
            Console.WriteLine(Mean(65.5, 23.9));

            //-- Dynamic expression
            dynamic list = new List<int>();
            //var result = list.Add(5); // RuntimeBinderException thrown since Add is void

            dynamic x = 2;
            var y = x * 3;
            Console.WriteLine(y);

            dynamic x2 = 2;
            var y2 = (int)x2;
            Console.WriteLine(y2);

            //-- Just to take into consideration:
            //-- we cannot call Extension method, or method of an interface
            ISimpleDuck simpleDucky = new SimpleDuck();
            simpleDucky.ShowDuck();
            dynamic simpDucky = simpleDucky;
            //simpDucky.ShowDuck(); //gonna give an error
        }

        /// <summary>
        /// Simple Duck class w/ no methods
        /// </summary>
        class SimpleDuck : ISimpleDuck
        {
            void ISimpleDuck.ShowDuck()
            {
                Console.WriteLine("Here is the ducky: 🦆");
            }
        }

        interface ISimpleDuck
        {
            void ShowDuck();
        }
        

        /// <summary>
        /// When inheriting from DynamicObject this is called <strong>Custom Binding</strong>
        /// </summary>
        class DynamicDuck : DynamicObject 
        {
            /// <summary>
            /// Will be called when trying to invoke a class member that doesn't exist
            /// </summary>
            /// <param name="binder"></param>
            /// <param name="args"></param>
            /// <param name="result"></param>
            /// <returns></returns>
            public override bool TryInvokeMember(
                InvokeMemberBinder binder, 
                object[] args, 
                out object result)
            {
                Console.WriteLine(binder.Name + " method was called");
                result = null;
                return true;
            }

            /// <summary>
            /// A existing method for DynamicDuck
            /// </summary>
            public void Walk()
            {
                Console.WriteLine("The Ducky is walking");
            }

        }

    }

}


