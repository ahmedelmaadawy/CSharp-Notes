namespace Day2___Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter A character");
            char input = char.Parse( Console.ReadLine());
            int output = input;
            Console.WriteLine($"The ASCII for {input} is {output} \n");

            // 2--------
            Console.WriteLine("Please enter a number to convert to character");
            int num = int.Parse( Console.ReadLine());
            char charOutput = Convert.ToChar( num );
            Console.WriteLine($"The character for the ASCII  {num} is {charOutput} \n");
            //3----------

            Console.WriteLine("Please Enter a number to disply odd or even");
            int oddOrEven = int.Parse( Console.ReadLine());
            Console.WriteLine($"The number you entered is " +( oddOrEven %2 ==0 ?"Even":"odd \n"));

            //4-------------
            Console.WriteLine("Please enter two numbers :  ");
            int num1 = int.Parse( Console.ReadLine());
            int num2 = int.Parse( Console.ReadLine());

            Console.WriteLine($"The sum of {num1} and {num2} is :{num1 + num2} ");

            Console.WriteLine($"The subtraction of {num1} and {num2} is :{num1 - num2} ");

            Console.WriteLine($"The multiply of {num1} and {num2} is :{num1 * num2} \n");

            //5----------------
            Console.WriteLine("Please Enter the student degree from 0 to 100");
            int degree = int.Parse( Console.ReadLine());

            if( degree >= 85)
            {
                Console.WriteLine("Your grade is  Excellent");
            } else if (degree >= 75)
            {
                Console.WriteLine("Your grade is  very good");
            } else if( degree >=65)
            {
                Console.WriteLine("Your grade is  good");
            }else if (degree >= 50 )
            {
                Console.WriteLine("Your grade is  that you passed ");
            }else
            {
                Console.WriteLine("Your grade is  you failed this class");
            }
            //6----------------
            Console.WriteLine("Please Enter the number for Multiplication table");
            int mult = int.Parse( Console.ReadLine());
            Console.WriteLine("The Multiplication Table : ");
            for (int i = 0; i <= 12; i++) {
                Console.WriteLine($"{i} * {mult}  = {i*mult}");
            }
        }
    }
}
