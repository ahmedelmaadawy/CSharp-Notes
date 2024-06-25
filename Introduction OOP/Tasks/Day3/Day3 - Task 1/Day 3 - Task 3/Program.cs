namespace Day_3___Task_3
{
    struct Rectangle
    {
        int width;
        int height;
        public int Width
        {
            get
            {
                return width;

            }
            set
            {
                if (value < 0)
                {
                    width = 0;
                }
                else
                {
                    width = value;
                }

            }
        }


        public int Height
        {
            get
            {
                return height;

            }
            set
            {
                if (value < 0)
                {
                    height = 0;
                }
                else
                {
                    height = value;
                }

            }

        }
         //methods 

        public int Area ()=> width*height;
        public int Perimeter() => (width + height) * 2;

        public string GetString() =>
             $"The width of the rectangle = {width}\nThe Height of the rectangle = {height}";
        





    }


    struct TimeSpan
    {
        int seconds;
        int minutes;
        int hours;

        public int Seconds { 
            get { 
                return seconds;
            
            }
            set
            {
                if (value > 60 || value < 0)
                    seconds = 0;
                else
                    seconds = value;
            }
        }

        public int Minutes {
            get
            {
                return minutes;

            }
            set
            {
                if (value > 60 || value < 0)
                    minutes = 0;
                else
                    minutes = value;
            }
        }
        public int Hours {
            get
            {
                return hours;

            }
            set
            {
                if (value > 24 || value < 0)
                    hours = 0;
                else
                    hours = value;
            }
        }

        public int TotalSeconds()
        {
            return seconds + (minutes * 60) + (hours * 60 * 60);
        }

        public string GetString()
        {
            return $"{hours}:{minutes}:{seconds}";
        }
    }

        internal class Program
         {
        static void Main(string[] args)
        {

            Rectangle rec   = new Rectangle();
            rec.Width = 20;
            rec.Height = 10;
            Console.WriteLine(rec.Area());
            Console.WriteLine(rec.Perimeter());
            Console.WriteLine(rec.GetString());

            TimeSpan time = new TimeSpan();
            time.Minutes = 50;
            time.Seconds = 40;
            time.Hours = 11;

            Console.WriteLine(time.TotalSeconds());
            Console.WriteLine(time.GetString());

            //array of time span
            Console.WriteLine($"Please enter the size of your time spans");
            int size= int.Parse( Console.ReadLine() );
            TimeSpan[] times = new TimeSpan[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"please enter the hours for timespan number {i+1}");
                times[i].Hours = int.Parse( Console.ReadLine() );

                Console.WriteLine($"please enter the minutes for timespan number {i + 1}");
                times[i].Minutes = int.Parse(Console.ReadLine());

                Console.WriteLine($"please enter the seconds for timespan number {i + 1}");
                times[i].Seconds = int.Parse(Console.ReadLine());

            }

            // print array of spans 
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine( times[i].GetString());
            }
            
            //sorting
            TimeSpan temp = times[0];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (times[i].TotalSeconds()< times[j].TotalSeconds())
                    {
                        temp = times[i];
                        times[i] = times[j];
                        times[j] = temp; 
                    }
                }
            }

            Console.WriteLine("The  sorted Array");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(times[i].GetString());
            }

        }
    }
}   
