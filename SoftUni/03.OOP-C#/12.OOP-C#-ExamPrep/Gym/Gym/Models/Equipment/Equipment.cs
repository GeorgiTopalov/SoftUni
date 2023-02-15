using Gym.Models.Equipment.Contracts;


namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight, decimal price)
        {
            this.weight = weight;
            this.Price = price;
        }
        public double Weight { get { return weight; } private set { this.weight = value; } }

        public decimal Price { get { return price; } private set { this.price = value; } }
    }
}
