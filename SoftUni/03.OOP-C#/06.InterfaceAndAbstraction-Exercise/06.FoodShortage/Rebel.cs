using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    
    public class Rebel : IHuman, IBuyer
    {
        private int food;

        public Rebel(string name, int age, string group)
        {
            
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }

        public int Food { get { return this.food; } set { this.food = value; } }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
