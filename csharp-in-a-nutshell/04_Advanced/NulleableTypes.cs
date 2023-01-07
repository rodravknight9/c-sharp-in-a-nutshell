namespace csharp_in_a_nutshell._04_Advanced
{
    internal class NulleableTypes
    {
    }

    public class Playground
    {
        public static void Main()
        {
            //-- value types cannot have a null value directly
            //-- they need to be nulleable
            int? a = null;
            Console.WriteLine(a == null);

            Nullable<int> a2 = new Nullable<int>();
            Console.WriteLine(!a2.HasValue);

            //-- since a2 is null will assign a default value, in this case 0
            var a3 = a2.GetValueOrDefault();
            Console.WriteLine(a3);

            int? x = 5; // implict
            int y = (int)x; // explicit

            //-- boxing and unboxing nulleable values
            object o = "string";
            int? o1 = o as int?;
            Console.WriteLine(x.HasValue);

            int? x_1 = 5;
            int? x_2 = 10;
            bool b_1 = x_1 < x_2;
            //-- the operation above is transalted to:
            bool b_2 = (x_1.HasValue && x_2.HasValue) ? (x_1.Value < x_2.Value) : false;

            //-- mixing nulleable and non-nullable operators
            int? c_1 = 5;
            int? c_2 = null;
            int? c_res = c_1 + c_2;
            Console.WriteLine("c_res has value? " + c_res.HasValue);

            //-- Using the ambient property technique
            Grid grid = new Grid()
            {
                Color = new Color() { Name = "Primary", HexValue = "#767812" },
                Name = "List of students"
            };

            Row row = new Row
            {
                Parent = grid,
                Color = null
            };

            //-- will take the parent's color
            Console.WriteLine($"{row.Color.Name} {row.Color.HexValue}");

        }
    }

    /// <summary>
    /// This Grid acts as the parent class for the Row class
    /// </summary>
    public class Grid
    {
        public Color Color { get; set; }
        public string Name { get; set; }
    }

    //-- The Row class uses someting called an ambient property:
    //-- An ambient property, if null, returns the value of its parent.
    /// <summary>
    /// The row class
    /// </summary>
    public class Row
    {
        Color? color;
        Grid parent;

        public Color Color
        {
            get { return color ?? parent.Color; }
            set { color = value == parent.Color ? (Color?)null : value; }
        }

        public Grid Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }

    /// <summary>
    /// Simple POCO color class
    /// </summary>
    public class Color
    {
        public string HexValue;
        public string Name;
    }
}
