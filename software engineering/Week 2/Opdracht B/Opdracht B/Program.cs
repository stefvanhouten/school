using System;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace Opdracht_B
{
    class Program
    {
        /*  This is a function. A function is used to keep small reusable code in seperate code blocks. 
         *  Instead of copy and pasting the code everywhere we need to we just call the function by name.
         *  In this case Fib();. 
         *  
         *  You might have noticed that this function has public static void in front of it.
         *  When we declare a function we need to specify the *Access Modifiers* The most common ones are: public, private, protected.
         *  For now we use public, which means everyone can access it. static is something that is not important for now.
         *  Void means that we return nothing, but when we want to return something we need to specify the type (string, int, bool, double, etc..). 
         *  
         *  Some functions, like this one, take parameters. Parameters are the variables the function needs to 
         *  produce meaningfull output. In this case the function takes the int n as parameter. 
         */
        public static void Fib(int n)
        {
            /*  Function that calculates fibonacci number based on n
             *  
             *  First 15 numbers of the fibonacci sequence:
             *  Numbers: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377
             *  Index:   0  1  2  3  4  5  6  7   8   9   10  11  12   13   14
             *  
             *  Parameters:
             *      n:  integer, location of the fibonacci number. ex; 
             *          0 would mean the first number in the sequence which in this case is 0
             *          14 would mean 377
             
             *  Console output:
             *      a:  integer, writes the fibonacci number to the console.
             */
            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                int c = a;
                a = b; 
                b = c + b;  
            }

            Console.WriteLine(a);
        }
        /*  
         */
        public static int diceThrow()
        {
            /*  Function that generates a random number between 1 and 6. 
             *  
             *  Returns:
             *      diceRoll:  integer, randomly generated number between 1 and 6
             */
            Random randomNumber = new Random(); //Create a new *Instance* of the Random class
            int diceRoll = randomNumber.Next(1, 7); //I know this says 7 but this actually means between 1 and 6
            return diceRoll; //Return the randomly generated number to the caller, which is the location where we called: diceThrow();
        }

        static void Main(string[] args)
        {
            //Create a loop starting at 0 and ending at 14. (< 15 means smaller than 15, which means it will stop at 14. Since we start at 0, 0-14 = 15)
            for (int i = 0; i < 15; i++)
            {
                //Call the function we created above
                Fib(i);
            }
            //Wait untill we press a key
            Console.ReadKey();
            //Declare ouur variables
            int number, multiplier, diceRollOne, diceRollTwo, sixesRolled;
            /* While true, which is always we start our loop. Be carefull with this!
             * This is an infinite loop, to exit this loop we need an exit condition. 
             * If you do not have an exit condition this will, in most languages fuck your pc up.
             */
            while (true)
            {
                //Clear the console
                Console.Clear();
                //Write our bullshit text
                Console.WriteLine("Choose a number between 5 and 100: ");
                //Console.Readline is a *method* that returns a string, we need to convert this bad boi to an integer
                number = Convert.ToInt32(Console.ReadLine());
                //If our number is smaller than 5 or bigger than 100 we nope the fuck out of here
                if(number < 5 || number > 100)
                {
                    /*  This will skip to the next iteration of the loop. This means we go back to the top of the while loop, in this case Console.Clear
                     */
                    continue; 
                }
                //Our exit condition! We reach this if we put in a number that is between 5 and 100.
                break;
            }
            /* Setting our variables to a value, this is the same as:
             * multiplier = 0;
             * sixesRolled = 0;
             * but we are really fucking lazy so we do it the lazy way!
             */
            multiplier = sixesRolled = 0;
            for (int i = 0; i < 4; i++)
            {
                //Call our diceThrow function to generate a random integer betwwen 1 and 6
                diceRollOne = diceThrow();
                diceRollTwo = diceThrow();
                //This reads as the following: if diceRollOne equals 6 OR diceRollTwo equals 6 
                if(diceRollOne == 6 || diceRollTwo == 6)
                {
                    //Add to our multiplier with +=, if the current value was 0 and we do += 50 it now is 50. If it was 10 and we do += 50 its 60.
                    multiplier += 50;
                    //Same shit different variable
                    sixesRolled += 1;
                }
                if(diceRollOne == diceRollTwo)
                {
                    multiplier += 10;
                }
                if(diceRollOne == 1 && diceRollTwo == 1)
                {
                    multiplier = 0;
                }
            }
            //Lets check how many sixes we rolled! If it is greater than or equal to 4 we add 2 to our multiplier
            if(sixesRolled >= 4)
            {
                multiplier += 2;
            }
            //Write to console
            Console.Write($"The multiplier: {multiplier}, sixes rolled: {sixesRolled} \n");
            //Insane math
            int profit = multiplier * number;
            //Here we check if we made a profit or lost some money. This is optional, you don't need to do this so you can just log your profit as well.
            if(profit > number)
            {
                Console.WriteLine($"Congratiulations you won {profit}. Your starting input was {number}");
            }
            else
            {
                Console.WriteLine($"Oof there goes your money. You recieve {profit}. Your starting input was {number}");
            }
            Console.ReadKey();
        }   

    }
}
