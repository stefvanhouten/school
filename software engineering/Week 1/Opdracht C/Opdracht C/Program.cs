using System;

namespace Opdracht_C
{
    class Program
    {
        static void Main(string[] args)
        {
            //Same shit as in excercise b, we declare some variable and initialize them later
            string name;
            char variable1;
            int number1;
            double number2, rest; //Same as declaring: double number2; double rest; this is faster tho, we skip on repeating double!
            bool status;
            //Initialize variable name. Couldve also done: string name = "Stef van Houten";
            name = "Stef van Houten";
            Console.WriteLine($"Hello {name}");
            
            variable1 = 'C';
            number1 = 123;
            number2 = 1.5;
            status = false;
            rest = number1 % number2; //Store the remainder of number1 % number2 in the variable rest

            Console.WriteLine(rest); //Write the rest value to the console
            Console.ReadKey(); //Wait untill we hit a key
            Console.Clear(); //Clear the console

            Console.WriteLine("Give a temperature in Celcius"); //Ask for input
            int temperatureCelcius = Int32.Parse(Console.ReadLine()); //Convert the input to an integer, Console.Readline() returns a string!
            double temperatureFarenheit = temperatureCelcius * 1.8 + 32; //Calculate the temp in farenheit, because some peasants still use this useless measurement. 7
            //Write 2 values to the console, when dealing with multiple variables it is good practice to spread them on new lines for readability.
            Console.Write($"Celcius: {temperatureCelcius} " + //Write the real measurement to the console
                          $"Farenheit: {temperatureFarenheit}"); //Write the peasant measurement to the console
            Console.ReadKey(); //Wait for inpuut
            Console.Clear(); //Clear the console

            decimal euro, dollar; //Declare variables
            Console.WriteLine("Give your input in EUR"); //Ask for input in a real currency(EUR)
            euro = Int32.Parse(Console.ReadLine()); //Parse the string to an int! Could also use: Convert.ToInt32(Console.Readline());
            dollar = euro * 1.16m; //Who the fuck uses dollars anyway? 
            Console.WriteLine($"{euro} EUR is {dollar} USD"); //Output to console
            Console.ReadKey(); //Wait for input
        } 
    }
}
