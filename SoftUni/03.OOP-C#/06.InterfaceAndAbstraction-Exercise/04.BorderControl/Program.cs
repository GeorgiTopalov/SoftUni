using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string,string> borderPassers = new Dictionary<string,string>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string iD = inputArgs[2];

                    Citizen citizen = new Citizen(name, age, iD);

                    borderPassers.Add(name,iD);
                }
                else
                {
                    string model = inputArgs[0];
                    string iD = inputArgs[1];

                    Robot robot = new Robot (model, iD);
                    borderPassers.Add(model, iD);
                }
            }

            string endOfID = Console.ReadLine();
            List<string> fakeIDs = new List<string>();

            foreach (var passer in borderPassers)
            {
                string substringToCompare = passer.Value.Substring(passer.Value.Length - endOfID.Length, endOfID.Length);

                if (substringToCompare == endOfID)
                {
                    fakeIDs.Add(passer.Value);
                }
            }

            foreach (string id in fakeIDs)
            {
                Console.WriteLine(id);
            }
        }
    }
}
