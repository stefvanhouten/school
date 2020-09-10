using System;

namespace Opdracht_C
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            char variable1;
            int number1;
            double number2, rest;
            bool status;

            name = "Stef van Houten";
            Console.WriteLine($"Hello {name}");

            variable1 = 'C';
            number1 = 123;
            number2 = 1.5;
            status = false;
            rest = number1 % number2;

            Console.WriteLine(rest);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Give a temperature in Celcius");
            int temperatureCelcius = Int32.Parse(Console.ReadLine());
            double temperatureFarenheit = temperatureCelcius * 1.8 + 32;
            Console.Write($"Celcius: {temperatureCelcius} " +
                          $"Farenheit: {temperatureFarenheit}");
            Console.ReadKey();
            Console.Clear();

            decimal euro, dollar;
            Console.WriteLine("Give your input in EUR");
            euro = Int32.Parse(Console.ReadLine());
            dollar = euro * 1.16m;
            Console.WriteLine($"{euro} EUR is {dollar} USD");
            Console.ReadKey();


        }
    }
}
