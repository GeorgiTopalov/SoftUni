using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Engine
    {
        public void Run()
        {
            string input = string.Empty;
            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "End")
            {

                string[] animalInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                AnimalFactory factory = new AnimalFactory();
                Animal animal = factory.CreateAnimal(animalInfo);


                string[] foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string food = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                animals.Add(animal);

                animal.ProduceSound();
                try
                {
                    animal.FeedAnimal(food, quantity);

                }
                catch (Exception ex)
                {

                    Console.WriteLine($"{ex.Message}");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}
