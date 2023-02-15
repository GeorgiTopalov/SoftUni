using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void FeedAnimal(string food, int foodQuantity)
        {
            if (food != "Meat" && food != "Vegetable")
            {
                throw new ArgumentException($"Cat does not eat {food}!");
            }
            this.Weight += foodQuantity * 0.30;
            base.FeedAnimal(food, foodQuantity);
        }

        public override void ProduceSound()
         => Console.WriteLine("Meow");

        public override string ToString()
        {
            return $"Cat [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
