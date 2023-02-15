using Formula1.Models.Contracts;
using System;


namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string name;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.CanRace = false;
        }

        public string FullName 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: { value }.");
                }
                this.name = value;
            }
        }

        public IFormulaOneCar Car 
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                this.car = value;
            }
        }

        public int NumberOfWins 
        {
            get => this.numberOfWins;
            private set => this.numberOfWins = value;
        }

        public bool CanRace
        {
            get => this.canRace;
            private set => this.canRace = value;
        } 

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot { this.FullName } has { this.NumberOfWins } wins.";
        }
    }
}
