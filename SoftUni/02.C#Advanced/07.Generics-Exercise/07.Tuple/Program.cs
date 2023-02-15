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
            CustomTuple<string, string> tuple = new CustomTuple<string, string>(name, place);

            string[] alcoholic = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<string, int> beerPersonDetails = new CustomTuple<string, int>(alcoholic[0], int.Parse(alcoholic[1]));

            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<int, double> twoNumbers = new CustomTuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

            Console.WriteLine($"{tuple.FirstItem} -> {tuple.SecondItem}");
            Console.WriteLine($"{beerPersonDetails.FirstItem} -> {beerPersonDetails.SecondItem}");
            Console.WriteLine($"{twoNumbers.FirstItem} -> {twoNumbers.SecondItem}");

        }
    }
}
