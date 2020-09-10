using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Opdracht_D
{
    class Program
    {
        static void Main(string[] args)
        {
            /*MULTI LINE COMMENT*/
            while (true)
            {
                Console.WriteLine("Choose your gender: \n" +
                    "1: Male \n" +
                    "2: Female \n");

                int gender = Int32.Parse(Console.ReadLine());
                if(gender < 1 || gender > 2)
                {
                    Console.WriteLine("Invalid input. Please try again! \n");
                    continue;
                }

                Console.WriteLine("What is your height in CM?:");
                double height = Double.Parse(Console.ReadLine());
                double idealWeight;
                if (gender == 1)
                {
                    idealWeight = (height - 100) * 0.9;
                }
                else
                {
                    Console.WriteLine("What is the circumference of your wrist in CM?: ");
                    double wristCircumference = Double.Parse(Console.ReadLine());
                    idealWeight = (height + 4 * wristCircumference - 100) / 2;
                }
                Console.WriteLine($"The ideal weight for your gender is: {idealWeight}kg");
                break;
            }
            Console.ReadKey();
            Console.Clear();

            Dictionary<string, List<string>> languages = new Dictionary<string, List<string>>()
            {
                { "1", new List<string>(){ "English", "Goodbye" } },
                { "2", new List<string>(){ "Dutch", "Doei" } },
                { "3", new List<string>(){ "French", "Au Revoir" } },
                { "4", new List<string>() { "German", "Guten tach" } },
                { "5", new List<string>(){ "Spanish", "??" } },
            };

            Console.WriteLine("Choose your language:");
            foreach(var item in languages)
            {
                Console.WriteLine($"{item.Key}. {item.Value[0]}");
            }
            int response = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(languages[$"{response}"][1]);
            Console.ReadKey();
        }
    }
}
