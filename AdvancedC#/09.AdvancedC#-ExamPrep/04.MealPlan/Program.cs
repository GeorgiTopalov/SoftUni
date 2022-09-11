using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allMeals = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] caloriesPerDay = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> meals = new Queue<string>(allMeals);
            Stack<int> calories = new Stack<int>(caloriesPerDay);

            int numberOfMealsEaten = 0;

            while (true)
            {
                string currentMeal = meals.Dequeue();
                int mealCalories = 0;

                if (currentMeal == "salad")
                {
                    mealCalories = 350;
                }
                else if (currentMeal == "soup")
                {
                    mealCalories = 490;
                }
                else if (currentMeal == "pasta")
                {
                    mealCalories = 680;
                }
                else
                {
                    mealCalories = 790;
                }
                int dailyCalories = calories.Peek();

                if (mealCalories < dailyCalories)
                {
                    calories.Push(calories.Pop() - mealCalories);
                }
                else
                {
                    int caloriesLeft = mealCalories - calories.Pop();

                    if (calories.Count != 0)
                    {
                        calories.Push(calories.Pop() - caloriesLeft);
                    }
                }

                numberOfMealsEaten++;

                if (meals.Count == 0 || calories.Count == 0)
                {
                    break;
                }
            }
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
