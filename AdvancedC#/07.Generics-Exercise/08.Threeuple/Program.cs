using System;
using System.Collections.Generic;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] personDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = $"{personDetails[0]} {personDetails[1]}";
            string place = personDetails[2];
            string town = personDetails[3];

            if (personDetails.Length > 4)
            {
                 town = $"{personDetails[3]} {personDetails[4]}";
            }
            
            Threeuple<string, string, string> person = new Threeuple<string, string, string>(name, place, town);

            string[] alcoholic = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            bool isDrunk = false;
            if (alcoholic[2] == "drunk")
            {
                isDrunk = true;
            }
            Threeuple<string, int, bool> beerPersonDetails = new Threeuple<string, int, bool>(alcoholic[0], int.Parse(alcoholic[1]), isDrunk);

            string[] bankDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, double, string> twoNumbers = new Threeuple<string, double, string>(bankDetails[0], double.Parse(bankDetails[1]), bankDetails[2]);

            Console.WriteLine($"{person.FirstItem} -> {person.SecondItem} -> {person.ThirdItem}");
            Console.WriteLine($"{beerPersonDetails.FirstItem} -> {beerPersonDetails.SecondItem} -> {beerPersonDetails.ThirdItem}");
            Console.WriteLine($"{twoNumbers.FirstItem} -> {twoNumbers.SecondItem} -> {twoNumbers.ThirdItem}");

        }
    }
}
