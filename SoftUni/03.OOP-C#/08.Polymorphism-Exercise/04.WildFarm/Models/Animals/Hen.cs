using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void FeedAnimal(string food, int foodQuantity)
        {
            this.Weight += foodQuantity * 0.35;
            base.FeedAnimal(food, foodQuantity);
        }

        public override void ProduceSound()
        => Console.WriteLine("Cluck");

        public override string ToString()
        {
            return $"Hen [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
        
    }
}
