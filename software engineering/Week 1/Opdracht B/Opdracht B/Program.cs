using System;

namespace Opdracht_B
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Stef van Houten";
            Console.WriteLine($"Hello {name}");

            char variable1 = 'C';
            int number1 = 123;
            double number2 = 1.5;
            bool status = false;
            double rest = number1 % number2;

            Console.WriteLine(rest);
            Console.ReadKey();
        }
    }
}
