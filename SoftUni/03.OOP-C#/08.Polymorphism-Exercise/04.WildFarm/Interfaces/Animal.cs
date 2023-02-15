using System;

namespace WildFarm
{
    public abstract class Animal : IFeedable
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public virtual void FeedAnimal(string food, int foodQuantity)
        {
            this.FoodEaten += foodQuantity;
        }
        public abstract void ProduceSound();
       
    }
}
