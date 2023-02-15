using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void FeedAnimal(string food, int foodQuantity)
        {
            if (food != "Meat")
            {
                throw new ArgumentException($"Owl does not eat {food}!");
            }
            this.Weight += foodQuantity * 0.25;
            base.FeedAnimal(food, foodQuantity);
        }

        public override void ProduceSound()
        => Console.WriteLine("Hoot Hoot");

        public override string ToString()
        {
            return $"Owl [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
        
    }
}
