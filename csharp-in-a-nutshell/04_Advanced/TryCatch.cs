namespace csharp_in_a_nutshell._04_Advanced
{
    internal class TryCatch
    {
    }

    public class TestTryCatch
    {
        public static void Test(string[] args)
        {
            try
            {
                byte b = byte.Parse(args[0]);
                Console.WriteLine(b);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Please provide at least one argument");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex) when (ex.Message == "Input string was not in a correct format.")
            {
                //-- this is a exception filter, will hit here if the statement matches
                Console.WriteLine("That's not a number!");
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException) // we don't ask for the parameter since we're not gonna use it
            {
                Console.WriteLine("You've given me more than a byte!");
            }
            finally
            {
                //-- finally will always hit
                Console.WriteLine("Wish you luck the next time");
            }
        }

        public static void ReadFile()
        {
            StreamReader reader = null!;

            try
            {
                // if a exception happens this could be easily avoided using the using() statement
                reader = File.OpenText("../../file.txt"); // you can change the path to force a exception
                if (reader.EndOfStream)
                    return;
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // need to close the reader whatever it happens
                if (reader != null)
                    reader.Dispose();
            }
        }

        
    }

}
