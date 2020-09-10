using System;

namespace Opdracht_A
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("FOR LOOP");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"2^{i} = " + Math.Pow(2, i));
                }
            }
            {
                Console.WriteLine("\nWHILE LOOP");

                bool doMath = true;
                int i = 0;
                while (doMath)
                {
                    if(i == 9)
                    {
                        doMath = false;
                    }
                    Console.WriteLine($"2^{i} = " + Math.Pow(2, i));
                    i++;
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
                int max, input;
                max = input = 0;
                for(int i = 0; i < 5; i++)
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if(i == 0)
                    {
                        max = input;
                    }
                    else
                    {
                        if(input > max)
                        {
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
