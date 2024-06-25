namespace Day2___Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = {7,0,0,0,5,6,7,5,0,7,5,3 };
            // int[] arr = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1 };
            Console.WriteLine("please enter the number of the array values");
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[number];
            Console.WriteLine("please enter the values of the array");
            for (int i = 0; i< number; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()); 
            }
            int currentNum = 0;
            int distance = 0;

            for (int i = 0; i < arr.Length; i++) {
                currentNum = arr[i];
                for (int j = arr.Length -1; j >= 0; j--) {
                    if (currentNum == arr[j]) {
                        if (distance < j-i-1) {
                            distance = j-i-1;
                        }
                        break;
                    }
                }
            
            }
            Console.WriteLine($"The distance  is {distance}");
        }
    }
}
