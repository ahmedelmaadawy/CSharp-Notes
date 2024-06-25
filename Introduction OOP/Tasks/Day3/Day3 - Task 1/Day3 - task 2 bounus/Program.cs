namespace Day3___task_2_bounus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the number of tracks");
            int Tracks = int.Parse(Console.ReadLine());
            int[][] ages = new int[Tracks][];
            for (int i = 0; i < Tracks; i++) {
                Console.WriteLine($"please enter the number of students in track number {i+1}");
                int students = int.Parse(Console.ReadLine());
                ages[i] = new int[students];
                for (int j = 0; j < students; j++) {
                    Console.WriteLine($"please enter the age of student number {j+1}");
                    ages[i][j] = int.Parse(Console.ReadLine());
                }
            }
            //---------------print output
            for (int i = 0; i < Tracks; i++)
            {
                Console.WriteLine($"The ages of students in track number {i+1}");
                for (int j = 0; j < ages[i].Length; j++) {

                    Console.WriteLine($"The age of student number {j+1} is {ages[i][j]}");
                }

            }
            //---------------avarage
            int avg = 0;
            for (int i = 0; i < Tracks; i++)
            {
                avg = 0;
                for (int j = 0; j < ages[i].Length; j++)
                {
                    avg += ages[i][j];
                }
                Console.WriteLine($"The avarage of ages in track number {i+1} = {avg / ages[i].Length}");
            }
        }
    }
}
