namespace Day3___Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the number of Students");
            int Students = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of tracks");
            int Tracks = int.Parse(Console.ReadLine());

            int[,] ages = new int[Students, Tracks];
            for (int i = 0; i < Students; i++)
            {
                Console.WriteLine($"Enter Student ages For Track {i+1}:");
                for (int j = 0;j<Tracks; j++)
                {
                    Console.WriteLine($"Enter The age of Student {j+1}");
                    ages[i,j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < Students; i++)
            {
                Console.WriteLine($"The Student ages For Track {i + 1}:");
                for (int j = 0; j < Tracks; j++)
                {
                    Console.WriteLine($"The age of Student {j+1} is {ages[i,j]}");
                    
                }
            }
            int avg = 0;
            //Calculating Avarage 

            for (int i = 0;i < Tracks; i++)
            {
                avg = 0;
                for  (int j = 0;j<Students; j++)
                {
                    avg+= ages[i,j];
                }
                Console.WriteLine($"The avarage of ages of students in track {i +1} = {avg/Students}");

            }



        }
    }
}
