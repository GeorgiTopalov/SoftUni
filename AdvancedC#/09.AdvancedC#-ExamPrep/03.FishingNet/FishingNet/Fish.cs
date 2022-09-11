namespace FishingNet
{
    public class Fish
    {
        string fishType;
        double length;
        double weight;

        public string FishType { get { return this.fishType; } set { this.fishType = value; } }
        public double Length { get { return this.length; } set { this.length = value; } }
        public double Weight { get { return this.weight; } set { this.weight = value; } }

        public Fish(string fishType, double length, double weight)
        {
            this.fishType = fishType;
            this.length = length;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
        }
    }
}
