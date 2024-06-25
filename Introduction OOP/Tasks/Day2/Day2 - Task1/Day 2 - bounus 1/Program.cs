namespace Day_2___bounus_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the size of the array :");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("please enter the values of the array ");
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            //1----------------------------
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
            }
            //2------------------------------
            Console.WriteLine($"The sum of the array is {sum}");
            int max = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            Console.WriteLine($"The maximum element is {max}");
            //3------------------------------------
            Console.WriteLine("please enter the number you want to know the number of occurency is");
            int specific = int.Parse(Console.ReadLine());
            int occ = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == specific)
                {
                    occ++;
                }
            }
            Console.WriteLine($"The number {specific} appered in the array {occ} times");
            //4-------------------------------------
            int[] reverse = new int[size];
            for (int i = 0; i < size; i++) {
                reverse[i] = arr[size - 1 - i];
            }
            Console.WriteLine("The reversed array is :");
            for (int i = 0; i < size; i++) {
                Console.WriteLine(reverse[i]);
            }
            //5---------------------------------------
            int[] dublic = new int[size];
            int[] res = new int[size];
            int ind = 0;
            Array.Copy(arr ,dublic , size);
            Array.Sort(dublic);
            res[0] = dublic[0];
            ind = 1;
            for (int i = 0; i < size; i++)
            {
                if (res[ind-1] != dublic[i])
                {
                    res[ind] = dublic[i];
                    ind++;
                }
            }
            Console.WriteLine("The array without dublication");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(res[i]);
            }
            //6---------------------
            int largest = arr[0], sec_largest = arr[0];
            for (int i = 0; i < size; i++)
            {
                if(largest < arr[i])
                {
                    sec_largest = largest;
                    largest = arr[i];
                }
                else if (arr[i]>sec_largest )
                {
                    sec_largest = arr[i];
                }
            }
            Console.WriteLine($"The second largest element is {sec_largest} maximum {largest}");
            //7---------------------------
            int min = 0 ;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] < arr[min])
                    min = i;

            }
            Console.WriteLine($"The index of the minimum element is {min}");
            
        
        }

    }
}
