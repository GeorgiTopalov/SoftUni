using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void FeedAnimal(string food, int foodQuantity)
        {
            if (food != "Fruit" && food != "Vegetable")
            {
                throw new ArgumentException($"Mouse does not eat {food}!");
            }
            this.Weight += foodQuantity * 0.10;
            base.FeedAnimal(food, foodQuantity);
        }

        public override void ProduceSound()
        => Console.WriteLine("Squeak");

        public override string ToString()
        {
            return $"Mouse [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
      
    }
}
