namespace Day5___Task_2
{
    internal class Program
    {
        static class Math
        {
            public static int Add(int x, int y) {
            
                return x + y;
            }
            public static int Subtract(int x, int y) { 
                return x - y;
            }
            public static int Multiply(int x, int y) { 
                return x * y; 
            }
            public static int Divide(int x, int y) {
                return x / y;
            }
        }
        static void Main(string[] args)
        {
            int x = 50, y = 10;
            Console.WriteLine($"{x} + {y} = {Math.Add(x,y)}");

            Console.WriteLine($"{x} - {y} = {Math.Subtract(x, y)}");

            Console.WriteLine($"{x} * {y} = {Math.Multiply(x, y)}");

            Console.WriteLine($"{x} / {y} = {Math.Divide(x, y)}");

        }
    }
}
