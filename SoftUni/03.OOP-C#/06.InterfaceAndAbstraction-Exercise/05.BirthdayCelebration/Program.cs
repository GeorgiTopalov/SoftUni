using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, string> birthdates = new Dictionary<string, string>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string being = inputArgs[0];

                if (being == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string iD = inputArgs[3];
                    string birthDate = inputArgs[4];

                    Citizen citizen = new Citizen(name, age, iD, birthDate);

                    birthdates.Add(name, birthDate);
                }
                else if (being == "Robot")
                {
                    string model = inputArgs[1];
                    string iD = inputArgs[2];

                    Robot robot = new Robot(model, iD);
                }
                else if (being == "Pet")
                {
                    string name = inputArgs[1];
                    string birthDate = inputArgs[2];

                    Pet pet = new Pet(name, birthDate);

                    birthdates.Add(name, birthDate);
                }
            }

            string year = Console.ReadLine();

            foreach (var date in birthdates.Values.Where(x => x.Substring(6, 4) == year))
            {
                Console.WriteLine(date);
            }
        }
    }
}
