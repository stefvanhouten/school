using System;

namespace Opdracht_A
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Alright first thing to notice is that we wrap most of our code in.
             *  The only reason why we do this is because of *scope*. I wanted to use the same *iterator* i, multiple times.
             *  For that to work i can't be in the scope where another variable named i was declared.
             */
            {
                Console.WriteLine("FOR LOOP");
                //Create a for loop that starts at 0 and ends at 9 (< 10 = 9)
                for (int i = 0; i < 10; i++)
                {
                    //Write to the console using *string interpolation*. Fancy way of adding a variable in a string like: $"Hello {myvar}";, instead of "Hello " + myvar; 
                    //Math.Pow handles the exponentiation, if i = 1 Math.Pow(2, i) is the same as Math.Pow(2, 1) which you would write as 2^1. It just calculates it for you.
                    Console.WriteLine($"2^{i} = " + Math.Pow(2, i));
                }
            }
            {
                //\n is a special character for new line
                Console.WriteLine("\nWHILE LOOP");
                //Declare our iterator i
                int i = 0;
                while (true)
                {
                    //Only when i has reached the value of 9 we go inside this if statement
                    if(i == 9)
                    {
                        break; //Exit condition, more details on this in excercise B
                    }
                    Console.WriteLine($"2^{i} = " + Math.Pow(2, i));
                    i++; //i++ just adds 1 to i.
                }
            }
            {
                Console.WriteLine("\nDO-WHILE LOOP");
                int i = 0;
                do
                {
                    Console.WriteLine($"2^{i} = " + Math.Pow(2, i));
                    i++;
                } while (i < 10);
            }
            Console.WriteLine("Give 5 whole numbers: ");
            {
                //Declare the two integers we need to determine which value is the highest.
                int max, input;
                //Same as writing max = 0; input = 0;
                max = input = 0;
                //So we need to ask the user for 4 numbers, so we use a loop to ask this shit 4 times
                for(int i = 0; i < 5; i++)
                {
                    input = Convert.ToInt32(Console.ReadLine()); //Console.Readline() returns a string, Convert this boi to an integer
                    //On the first iteration write the input to the max value, there couldn't possibly be a higher number yet because we didn't ask for anything up untill now!
                    if(i == 0)
                    {
                        //The highest number for now is the first input value
                        max = input;
                    }
                    else
                    {
                        //On every other iteration(1-3) we end up here. 0 was the first iteration because programmers start counting at 0. 
                        //If this input number is higher than the current value in max we enter this if statement
                        if(input > max)
                        {
                            //Overwrite the current value in max. Maybe this variable has a shitty name and should be called highestNumber *camelCase*
                            max = input;
                        }
                    }
                }
                Console.WriteLine($"The highest number was: {max}");
            }
            Console.ReadKey();
        }
    }
}
