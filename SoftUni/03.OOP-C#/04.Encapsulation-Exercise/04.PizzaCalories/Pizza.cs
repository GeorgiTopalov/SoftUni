using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;
        

        public Pizza(string name, Dough dough)
        {
            this.Dough = dough;
            this.Name = name;
            this.toppings = new List<Topping>();
        }
      
        public string Name
        {
            get 
            {
                return name;
            }
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }
        public IReadOnlyCollection<Topping> Toppings => toppings;
        
       
        public void AddTopping(Topping topping)
        {
            if(toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public double Calories()
        {
            double toppingsCal = 0;

            foreach (Topping topping in toppings)
            {
                toppingsCal += topping.Calories;
            }

            return dough.Calories + toppingsCal;
        }
    }
}
