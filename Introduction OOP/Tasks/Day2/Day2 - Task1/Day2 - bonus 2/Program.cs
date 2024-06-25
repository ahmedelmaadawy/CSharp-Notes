using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day2___bonus_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //calculate ones

            int count = 0;
            for (int i = 0; i <= 999999; i++)
            {

                string numberString = i.ToString();

                foreach (char c in numberString)
                {
                    if (c == '1')
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Total number of 1s from 1 to 999999: " + count );

            //1   11 21 31 41 51 61 71 81 91                  ===> 20
            //100 101 102 103 104 105 106 107 108 109 110 111 ===>280 ( 20 *9 )+ 1 * 100
            //1000 1001 1002                                  ===>3700   (300 * 9) + 1000
            // 10000                                          ===>46_000 (4000 *9) + 10000
            //100000                                          ===>550000

            int n = 999999;
            count = 0;
            for (int i = 1; i < n; i*=10)
            {
                
                count +=((count * 9) + i ); 

            }
            Console.WriteLine("Total number of 1s from 1 to 999999: " + count );
        }
    }
}
                

            
       

    


