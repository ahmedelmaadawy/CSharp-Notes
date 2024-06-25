namespace Day_2___Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please Enter the number of the students :");
            int numberOfStudents = int.Parse(Console.ReadLine());
            int[] Grades = new int[numberOfStudents];
            
            Console.WriteLine("\nPlease enter the grades : \n");
            for (int i = 0; i < numberOfStudents; i++)
            {
                Grades[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("The Grades Of the students : \n");
            for (int i = 0; i < numberOfStudents; i++) {
                Console.WriteLine($"The Grade of the student Number {i+1} is : {Grades[i]} ");
            }
            int avarage = 0;
            for (int i = 0; i < numberOfStudents; i++) {
                avarage += Grades[i];
            }
            avarage /= numberOfStudents;
            Console.WriteLine($"The Avarage of all students grades : {avarage}");


        }
    }
}
