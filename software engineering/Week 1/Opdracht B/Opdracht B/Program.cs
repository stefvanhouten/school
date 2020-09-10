using System;

namespace Opdracht_B
{
    class Program
    {
        static void Main(string[] args)
        {
            /* *Declare* our string variable and *initialize* a value to the variable.
             *  Our variable's name is 'name'. If we want to output the value that our variable stores we need to *call* it. 
             */
            string name = "Stef van Houten";
            /* Call the Console.WriteLine function to show our output in the console.
             * Writing Console.WriteLine($"Hello {name}"); is a fancy way of calling Console.WriteLine("Hello " + name);
             * Using this improves readability and makes it easy to maintain!
             */
            Console.WriteLine($"Hello {name}");

            /* Declare a variable of type char and give it the name variable1. Note that we use '' instead of "".
             * The reason for this is because we are dealing with a *literal* which is not important for now.
             */

            char variable1 = 'C';
            //Declare a integer with the name number1 and set the value to 123. Note that we do not use any "" or ''. This is because we are dealing with a number.
            int number1 = 123;
            /* A double stores numbers as well, but these numbers can contain decimal numbers. 
             * A *float* can also store a decimal number but is less precise, it is however, faster! 
             * A *decimal* is used when we are dealing with money, this is because we need a lot of precision. 
             * A decimal is slow as fuck but it gives high accuracy.
             */
            double number2 = 1.5;
            // A boolean is either true or false. When naming a boolean you should name it so you can tell it is a boolean, consider names like isTrue, isFalse, hasValue, etc..
            bool status = false;
            /*  % is the remainder operator. Some other imporant *Arithmetic operators* are: 
             *  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
             */
            double rest = number1 % number2;

            Console.WriteLine(rest);
            //Wait untill we touch any key before closing the console
            Console.ReadKey();
        }
    }
}
