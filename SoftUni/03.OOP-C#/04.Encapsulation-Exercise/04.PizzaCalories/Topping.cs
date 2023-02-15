using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;
        private double calories;
        private double modifier;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;

            if (toppingType == "meat")
            {
                modifier = 1.2;
            }
            else if (toppingType == "veggies")
            {
                modifier = 0.8;
            }
            else if (toppingType == "cheese")
            {
                modifier = 1.1;
            }
            else if (toppingType == "sauce")
            {
                modifier = 0.9;
            }
            this.Calories = Weight * 2 * modifier;

        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType[0].ToString().ToUpper() + ToppingType.Substring(1)} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                this.calories = value;
            }
        }

        
        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value[0].ToString().ToUpper() + value.Substring(1)} on top of your pizza.");
                }
                toppingType = value;
            }
        }
    }
}
