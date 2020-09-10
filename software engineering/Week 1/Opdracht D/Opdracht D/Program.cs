using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Opdracht_D
{
    class Program
    {
        static void Main(string[] args)
        {
            /*MULTI LINE COMMENT, I'm not gonna copy all that shit from prev exercise in this one because it will be a mess*/
            //Might wanna check out WEEK 2 loops first? 
            while (true)
            {
                //Ask for the only 2 REAL genders out there. If you believe people can identify as apache helicopters go ahead and add that shit
                Console.WriteLine("Choose your gender: \n" +
                    "1: Male \n" +
                    "2: Female \n");

                int gender = Int32.Parse(Console.ReadLine()); //Convert this stringy boi to an integer
                //Check if any option besides 1 or 2 was checked, this couldve been done in multiple other ways but this is fine. 
                //If you want to add more genders make sure to update: gender > (2) to however many you add
                if(gender < 1 || gender > 2)
                {
                    //Some users are actually retarded so we need to make sure they selected a valid option.
                    Console.WriteLine("Invalid input. Please try again! \n");
                    continue; //This is explained in Week 2, but it basicly means go to the next iteration and start from the top
                }

                Console.WriteLine("What is your height in CM?:"); //Ask for height in the only right measurement system. METRIC FUCK YEAHH
                double height = Double.Parse(Console.ReadLine()); //Again convert the stringy boi to an integer
                double idealWeight; //Declare another variable. We declare this one here because it can be used in both male and female scope!
                /* So since we have 2 options we only need an if else, if gender == 1 (Male) we enter this block.
                 * If you want to add more genders you need to add an else if(gender == (2)<- whatever the number you want to catch here) clause.
                 * If you add like 10 genders you might wanna use a switch statement.
                 */
                if (gender == 1)
                {
                    idealWeight = (height - 100) * 0.9; //Initialize the variable idealWeight
                }
                else
                {
                    //If gender is not 1, so since we made sure only 1 or 2 could be selected, it must be female. Continue here with female calc.
                    Console.WriteLine("What is the circumference of your wrist in CM?: ");
                    double wristCircumference = Double.Parse(Console.ReadLine()); //Declare and initialize this variable here because it is female specific. Can only be used in this scope!
                    idealWeight = (height + 4 * wristCircumference - 100) / 2; //Some quick methhh
                }
                Console.WriteLine($"The ideal weight for your gender is: {idealWeight}kg"); //Output the idealweight variable
                break;
            }
            Console.ReadKey();
            Console.Clear();

            //Ok this is going to be way to hard to explain. Just take a look at Mark Hooijberg's code in the HBO-ICT Eerste jaars discord programming channel
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
