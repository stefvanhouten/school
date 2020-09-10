using System;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace Opdracht_B
{
    class Program
    {

        public static void Fib(int n)
        {
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

        public static int diceThrow()
        {
            Random randomNumber = new Random();
            int diceRoll = randomNumber.Next(1, 7);
            return diceRoll;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                Fib(i);
            }
            Console.ReadKey();
            int number, multiplier, diceRollOne, diceRollTwo, sixesRolled;
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose a number between 5 and 100: ");
                number = Convert.ToInt32(Console.ReadLine());
                if(number < 5 || number > 100)
                {
                    continue;
                }
                break;
            }
            multiplier = sixesRolled = 0;
            for (int i = 0; i < 4; i++)
            {
                diceRollOne = diceThrow();
                diceRollTwo = diceThrow();
                if(diceRollOne == 6 || diceRollTwo == 6)
                {
                    multiplier += 50;
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
            if(sixesRolled >= 4)
            {
                multiplier += 2;
            }
            Console.Write($"The multiplier: {multiplier}, sixes rolled: {sixesRolled} \n");
            int profit = multiplier * number;
            if(profit > number)
            {
                Console.WriteLine($"Congratiulations you won {multiplier * number}. Your starting input was {number}");
            }
            else
            {
                Console.WriteLine($"Oof there goes your money. You recieve {multiplier * number}. Your starting input was {number}");
            }
            Console.ReadKey();
        }   

    }
}
