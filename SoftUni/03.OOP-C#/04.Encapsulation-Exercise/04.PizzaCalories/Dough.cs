using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double flourModifier;
        private double techniqueModifier;
        private double calories;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            if (this.FlourType == "white")
            {
                flourModifier = 1.5;
            }
            else if (this.FlourType == "wholegrain")
            {
                flourModifier = 1.0;
            }
            if (this.BakingTechnique == "crispy")
            {
                techniqueModifier = 0.9;
            }
            else if (this.BakingTechnique == "chewy")
            {
                techniqueModifier = 1.1;
            }
            else if (this.BakingTechnique == "homemade")
            {
                techniqueModifier = 1.0;
            }
            this.Calories = Weight * 2 * flourModifier * techniqueModifier;
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
        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {

                return this.bakingTechnique;
            }
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

    }
}
