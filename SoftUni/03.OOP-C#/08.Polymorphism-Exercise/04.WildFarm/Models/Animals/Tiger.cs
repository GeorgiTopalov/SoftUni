using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void FeedAnimal(string food, int foodQuantity)
        {
            if (food != "Meat")
            {
                throw new ArgumentException($"Tiger does not eat {food}!");
            }
            this.Weight += foodQuantity * 1.00;
            base.FeedAnimal(food, foodQuantity);
        }

        public override void ProduceSound()
         => Console.WriteLine("ROAR!!!");

        public override string ToString()
        {
            return $"Tiger [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";

        }
    }
}
