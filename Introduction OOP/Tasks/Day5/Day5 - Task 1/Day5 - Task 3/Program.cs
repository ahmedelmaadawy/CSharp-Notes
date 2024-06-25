namespace Day5___Task_3
{
    class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public Duration()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
        public Duration(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        public Duration(int seconds)
        {
            if (seconds / 3600 >= 1)
            {
                Hours = seconds / 3600;
                seconds %= 3600;
            }
            if (seconds / 60 > 1)
            {
                Minutes = seconds / 60;
                seconds %= 60;
            }
            Seconds = seconds;

        }
        public static Duration operator +(Duration d1 ,Duration d2){
            return new Duration(CalculateSeconds(d1)+ CalculateSeconds(d2));
        }
        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(CalculateSeconds(d1)-CalculateSeconds(d2));
        }
        public static Duration operator +(Duration d1, int seconds)
        {
            return d1 + new Duration(seconds);
        }
        public static Duration operator ++(Duration d)
        {
            return new Duration(CalculateSeconds(d) +60);
        }
        public static Duration operator --(Duration d)
        {
            return new Duration(CalculateSeconds(d) - 60);
        }
        public static bool operator >(Duration d1,Duration d2)
        {
            if(CalculateSeconds(d1)>CalculateSeconds(d2))
                return true;
            return false;
        }
        public static bool operator <(Duration d1, Duration d2)
        {
            if (CalculateSeconds(d1) < CalculateSeconds(d2))
                return true;
            return false;
        }
        public static bool operator >=(Duration d1, Duration d2)
        {
            if (CalculateSeconds(d1) > CalculateSeconds(d2)||CalculateSeconds(d1)==CalculateSeconds(d2))    
                return true;
            return false;
        }
        public static bool operator <=(Duration d1, Duration d2)
        {
            if (CalculateSeconds(d1) < CalculateSeconds(d2) || CalculateSeconds(d1) == CalculateSeconds(d2))
                return true;
            return false;
        }
        public static explicit operator Duration(int x)
        {
            return new Duration((int)x);
        }
        public string GetString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }
        public static int CalculateSeconds(Duration d)
        {
            return (d.Hours*60*60)+(d.Minutes*60)+d.Seconds;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration d1 = new Duration(666);
            Console.WriteLine(d1.GetString());
            Duration d2 = new Duration(3600);
            Console.WriteLine(d2.GetString());
            Duration d3 = new Duration();
            d3 = d1 + d2;

            Console.WriteLine($"D3 = {d3.GetString()}");
            d3 = d1 + 70000;
            Console.WriteLine(d3.GetString());
            d3++;
            d3++;
            Console.WriteLine(d3.GetString());
            d3--;
            Console.WriteLine(d3.GetString());
            Duration d4 = new Duration(5000);
            Duration d5 = new Duration(4500);
            Console.WriteLine($"d4<d5 : {d4==d5}");
            Duration d7 = (Duration)3600;
            Console.WriteLine($"d7 = {d7.GetString()} ");
        }
    }
}
