using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void FeedAnimal(string food, int foodQuantity)
        {
            if (food != "Meat")
            {
                throw new ArgumentException($"Dog does not eat {food}!");
            }
            this.Weight += foodQuantity * 0.40;
            base.FeedAnimal(food, foodQuantity);

        }

        public override void ProduceSound()
        => Console.WriteLine("Woof");
        public override string ToString()
        {
            return $"Dog [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
