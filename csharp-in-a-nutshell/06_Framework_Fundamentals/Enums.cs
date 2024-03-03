namespace csharp_in_a_nutshell._06_Framework_Fundamentals
{
    internal class Enums
    {
    }

    public class EnumsPlayground 
    {

        public static void Play()
        {
            Display(Nut.Macadamia); // Nut.Macadamia
            Display(Size.Large); // Size.Large

            //-- Numeric enums conversion
            int i = (int)BorderSides.Top;
            Console.WriteLine(i);
            BorderSides side = (BorderSides)i;
            Console.WriteLine(side);

            object result = GetBoxedIntegralValue(BorderSides.Top);
            Console.WriteLine(result);
            Console.WriteLine(result.GetType());

            object bs = Enum.ToObject(typeof(BorderSides), 3);
            Console.WriteLine(bs);

            //-- string enums conversion
            BorderSides leftRight = (BorderSides)Enum.Parse(typeof(BorderSides), "Left, Right");
            Console.WriteLine(leftRight);

            //-- enumerating
            foreach (Enum value in Enum.GetValues(typeof(BorderSides)))
                Console.WriteLine(value);
        }

        static void Display(Enum value)
        {
            Console.WriteLine(value.GetType().Name + "." + value.ToString());
        }

        /// <summary>
        /// Only worsk with integers
        /// </summary>
        /// <param name="anyEnum"></param>
        /// <returns></returns>
        static int GetIntegralValue(Enum anyEnum)
        {
            return (int)(object)anyEnum;
        }

        static decimal GetAnyIntegralValue(Enum anyEnum)
        {
            return Convert.ToDecimal(anyEnum);
        }

        static object GetBoxedIntegralValue(Enum anyEnum)
        {
            Type integralType = Enum.GetUnderlyingType(anyEnum.GetType());
            return Convert.ChangeType(anyEnum, integralType);
        }
    }

    enum Nut { Walnut, Hazelnut, Macadamia }
    enum Size { Small, Medium, Large }

    [Flags] 
    public enum BorderSides 
    {
        Left = 1, 
        Right = 2, 
        Top = 4, 
        Bottom = 8 
    }

    /// <summary>
    /// Color use an underlying type: short
    /// </summary>
    public enum Color : short
    {
        Red = 1,
        Green = 2,
        Blue = 3
    }

}
