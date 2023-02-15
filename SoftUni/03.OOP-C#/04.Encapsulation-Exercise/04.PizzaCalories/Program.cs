using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {
                string[] pizzaInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                if (pizzaInfo.Length < 2 || string.IsNullOrWhiteSpace(pizzaInfo[1]))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                string[] DoughArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = pizzaInfo[1];

                string doughType = DoughArgs[1].ToLower();
                string doughTechnique = DoughArgs[2].ToLower();
                int weight = int.Parse(DoughArgs[3]);
                Dough dough = new Dough(doughType, doughTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);


                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string toppingType = inputArgs[1].ToLower();
                    int toppingWeight = int.Parse(inputArgs[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories():f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
