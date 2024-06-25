namespace Day3___Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[10, 10];
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) { 
                arr[i, j] = (i+1) *(j+1);
                }
            }

            for (int i = 0; i < 10; i++) {

                for (int j = 0; j < 10; j++) {
                    Console.WriteLine($"Number {i+1} * {j+1}  = {arr[i,j]}");

                }
            }
        }
    }
}
