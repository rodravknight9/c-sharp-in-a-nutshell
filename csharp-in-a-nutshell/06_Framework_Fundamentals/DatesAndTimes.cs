namespace csharp_in_a_nutshell._06_Framework_Fundamentals
{
    public class DatesAndTimes
    {
    }

    public class DatesAndTimesPlayground
    {

        public static void Play()
        {
            Console.WriteLine(new TimeSpan(2, 30, 0)); // 02:30:00
            Console.WriteLine(TimeSpan.FromHours(2.5)); // 02:30:00
            Console.WriteLine(TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30)); // 02:30:00 
            Console.WriteLine(TimeSpan.FromDays(10) - TimeSpan.FromSeconds(1)); // 9:23:59:59

            // DateTimeOffset can be convinient for international dates
            // DateTime can be conviniento for task in the local time machine

            Console.WriteLine(new DateTime(5767, 1, 1, new System.Globalization.HebrewCalendar()));
            Console.WriteLine(new DateTime(5767, 1, 1, new System.Globalization.GregorianCalendar()));

            var dateOffset = new DateTimeOffset(2023, 4, 29, 8, 10, 1, TimeSpan.FromHours(-4));
            Console.WriteLine(dateOffset);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTimeOffset.Now);

            TimeSpan ts = TimeSpan.FromMinutes(90);
            Console.WriteLine(dt.Add(ts));
            Console.WriteLine(dt + ts);

        }

    }
}
