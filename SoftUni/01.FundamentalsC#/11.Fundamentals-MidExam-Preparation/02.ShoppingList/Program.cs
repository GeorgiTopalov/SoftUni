using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] split = input.Split();
                string command = split[0];
                string item = split[1];

                if (command == "Urgent")
                {
                    AddToShoppingList(shoppingList, item);
                }
                else if (command == "Unnecessary")
                {
                    RemoveFromShoppingList(shoppingList, item);
                }
                else if (command == "Correct")
                {
                    string newItem = split[2];
                    CorrectShoppingList(shoppingList, item, newItem);
                }
                else
                {
                    RearrangeShoppingList(shoppingList, item);
                }
            }
            Console.WriteLine(String.Join(", ", shoppingList));
        }

        static List<string> AddToShoppingList(List<string> shoppingList, string item)
        {

            if (shoppingList.Contains(item))
            {
                return shoppingList;
            }
            else
            {
                shoppingList.Insert(0, item);
                return shoppingList;
            }

        }
        static List<string> RemoveFromShoppingList(List<string> shoppingList, string item)
        {

            if (!shoppingList.Contains(item))
            {
                return shoppingList;
            }
            else
            {
                shoppingList.Remove(item);
                return shoppingList;
            }

        }
        static List<string> CorrectShoppingList(List<string> shoppingList, string item, string newItem)
        {

            if (!shoppingList.Contains(item) || shoppingList.Contains(newItem))
            {
                return shoppingList;
            }
            else
            {
                for (int i = 0; i < shoppingList.Count; i++)
                {
                    if (shoppingList[i] == item)
                    {
                        shoppingList.RemoveAt(i);
                        shoppingList.Insert(i, newItem);
                    }
                }
                return shoppingList;
            }

        }
        static List<string> RearrangeShoppingList(List<string> shoppingList, string item)
        {

            if (!shoppingList.Contains(item))
            {
                return shoppingList;
            }
            else
            {
                shoppingList.Insert(shoppingList.Count, item);
                shoppingList.Remove(item);
                return shoppingList;
            }
        }
    }
}
