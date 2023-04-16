namespace csharp_in_a_nutshell._04_Advanced
{
    public class UnsafeCodeAndPointers
    {
        // To understand this chapter it's recomended to have clear how pointers works in C or C++
    }

    public class UnsafeCodeAndPointersPlayground
    {
        public static void Play()
        {

            Test test = new Test();
            unsafe
            {
                // sets the value of x using the p pointer
                fixed (int* p = &test.x)
                {
                    *p = 9;
                }
                System.Console.WriteLine(test.x);
            }

            int[,] bitmap = new int[5, 5]
            {
                { 0xFF0000, 0xFF0000, 0xFF0000, 0xFF0000, 0xFF0000 },
                { 0xFF0000, 0xFF0000, 0x00FF00, 0xFF0000, 0xFF0000 },
                { 0xFF0000, 0x00FF00, 0x00FF00, 0x00FF00, 0xFF0000 },
                { 0xFF0000, 0xFF0000, 0x00FF00, 0xFF0000, 0xFF0000 },
                { 0xFF0000, 0xFF0000, 0xFF0000, 0xFF0000, 0xFF00FF }// this guy is blue
            };
            BlueFilter(bitmap);

            UseOfStackalloc();
        }

        class Test 
        {
            public int x;
        }

        unsafe static void BlueFilter(int[,] bitmap)
        {
            int length = bitmap.Length;
            // b gets the address in memory
            // using fixed the garbage collector does not move the array while the method is executing
            fixed (int* b = bitmap)
            {
                // p gets the same memory allocation as b
                int* p = b;
                for (int i = 0; i < length; i++)
                    *p++ &= 0xFF; 

                // *p desrefernce the pointer to get the value
                // ++ points to the next pixel
            }
        }

        unsafe static void UseOfStackalloc()
        {
            int* a = stackalloc int[10];
            for (int i = 0; i < 10; ++i)
                Console.WriteLine(a[i]);
        }


    }
}
